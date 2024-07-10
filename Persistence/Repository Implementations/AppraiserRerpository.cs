using Application.Contracts.ILogging;
using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands;
using Application.StaticDetails;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Persistence.DatabaseContext;


namespace Persistence.Repository_Implementations
{
    public class AppraiserRerpository : GenericRepository<Form>, IAppraiserRerpository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppLogger<AppraiserRerpository> _appLogger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AppraiserRerpository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, IAppLogger<AppraiserRerpository> appLogger, IWebHostEnvironment hostEnvironment) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _appLogger = appLogger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Unit> AcceptTheFormThatWasAssigned(int? acceptFromId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID was not found.");
            }

            _appLogger.LogInformation($"Starting to accept form with ID {acceptFromId} for user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == acceptFromId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {acceptFromId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {acceptFromId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {acceptFromId}. Accepting form...");

                    formFromDb.FromAccepted = DateTime.Now;
                    formFromDb.Status = FormStatus.StatusAccepted;

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();


                    FormInteractionLog interactionLog = new()
                    {
                        FormId = formFromDb.Id,
                        ApplicationUserId = formFromDb.AppraiserId,
                        Status = formFromDb.Status,
                        LastUpdated = DateTime.Now,
                        AppraiserNote = formFromDb.AppraiserNote
                    };
                    await _dbContext.AddAsync(interactionLog);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form {acceptFromId} accepted successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {acceptFromId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while accepting form {acceptFromId} for user {userId}.", ex);               
            }

            throw new BadRequestException("An error occurred while accepting this job. Please refresh and try again.");
        }

        public async Task<IEnumerable<Form>> GetFormThatWasAssignedToAppraiser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;

            List<string> statusList = new()
            {
                FormStatus.StatusAssigned,
                FormStatus.StatusAccepted,
                FormStatus.StatusInProcess,
                FormStatus.StatusApproved,
                FormStatus.StatusReturnToAppraiser,
                FormStatus.StatusSubmitForApproval,
            };

            return await _dbContext.Forms//.Include(x => x.Region)
                                         .Where(x => x.AppraiserId == userId && statusList
                                         .Contains(x.Status))
                                         .Include(x => x.Appraiser)
                                         //.Include(x => x.ServiceRequestFormServiceRequestItem)
                                         //.ThenInclude(x => x.ServiceRequestItem)
                                         //.Include(x => x.ServiceRequesFormTypeOfPropertyItem)
                                         //.ThenInclude(x => x.TypeOfPropertyItem)
                                         //.Include(x => x.ServiceRequestFormPurposeOfValuationItem)
                                         //.ThenInclude(x => x.PurposeOfValuationItem)
                                         .ToListAsync();
        }

        public async Task<Unit> MarkTheFormAsInProcessThatWasAssigned(int? inProcessFromId)
        {
            if (inProcessFromId == null)
            {
                _appLogger.LogWarning("Form ID is null.");
                throw new ArgumentNullException(nameof(inProcessFromId), "Form ID cannot be null.");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to mark form with ID {inProcessFromId} as in process for user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == inProcessFromId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {inProcessFromId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {inProcessFromId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {inProcessFromId}. Marking form as in process...");

                    formFromDb.FormInProcess = DateTime.Now;
                    formFromDb.Status = FormStatus.StatusInProcess;

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();

                    FormInteractionLog interactionLog = new()
                    {
                        FormId = formFromDb.Id,
                        ApplicationUserId = formFromDb.AppraiserId,
                        Status = formFromDb.Status,
                        LastUpdated = DateTime.Now,
                        AppraiserNote = formFromDb.AppraiserNote
                    };
                    await _dbContext.AddAsync(interactionLog);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form {inProcessFromId} marked as in process successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {inProcessFromId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while marking form {inProcessFromId} as in process for user {userId}.", ex);          
            }

            throw new BadHttpRequestException("An error occurred while marking this job as in process. Please refresh and try again.");
        }

        public async Task<Unit> RejectTheFormThatWasAssigned(int? rejectFromId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to reject form with ID {rejectFromId} for user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == rejectFromId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {rejectFromId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {rejectFromId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {rejectFromId}. Rejecting form...");

                    formFromDb.RejectedForm = DateTime.Now;
                    formFromDb.Status = FormStatus.StatusRejected;

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();

                    FormInteractionLog interactionLog = new()
                    {
                        FormId = formFromDb.Id,
                        ApplicationUserId = formFromDb.AppraiserId,
                        Status = formFromDb.Status,
                        LastUpdated = DateTime.Now,
                        AppraiserNote = formFromDb.AppraiserNote
                    };
                    await _dbContext.AddAsync(interactionLog);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form {rejectFromId} rejected successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {rejectFromId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while rejecting form {rejectFromId} for user {userId}.", ex);
                
            }

            throw new BadHttpRequestException("An error occurred while rejecting this job. Please refresh and try again.");
        }

        public async Task<Unit> SubmitFormForApprovalThatWasAssigned(int? submitFormForApproval, IFormFile frontImage, IFormFile leftImage, IFormFile rightImage, IFormFile backImage)
        {
            if (submitFormForApproval == null)
            {
                _appLogger.LogWarning("Form ID is null.");
                throw new ArgumentNullException(nameof(submitFormForApproval), "Form ID cannot be null.");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to submit form with ID {submitFormForApproval} for approval by user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == submitFormForApproval);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {submitFormForApproval} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {submitFormForApproval} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    string webRootPath = _hostEnvironment.WebRootPath;
                    var uploads = Path.Combine(webRootPath, "images/property");

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    formFromDb.Status = FormStatus.StatusSubmitForApproval;
                    formFromDb.SubmittedFormForApproval = DateTime.Now;
                    formFromDb.FrontOfProperyImageURL = await SavePropertyImage(frontImage, uploads);
                    formFromDb.LeftSideOfPropertImageURL = await SavePropertyImage(leftImage, uploads);
                    formFromDb.RightSideOfPropertyImageURL = await SavePropertyImage(rightImage, uploads);
                    formFromDb.BackOfPropertyImageURL = await SavePropertyImage(backImage, uploads);

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();

                    FormInteractionLog interactionLog = new()
                    {
                        FormId = formFromDb.Id,
                        ApplicationUserId = formFromDb.AppraiserId,
                        Status = formFromDb.Status,
                        LastUpdated = DateTime.Now,
                        AppraiserNote = formFromDb.AppraiserNote
                    };
                    await _dbContext.AddAsync(interactionLog);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form with ID {submitFormForApproval} submitted for approval successfully by user {userId}.");

                    return Unit.Value;
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while submitting form {submitFormForApproval} for approval by user {userId}.", ex);
            }

            throw new BadHttpRequestException("An error occurred while submitting this job for approval. Please refresh and try again.");
        }

        private async Task<string> SavePropertyImage(IFormFile image, string uploadsPath)
        {
            if (image == null || image.Length == 0)
            {
                return null;
            }

            string newFileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(image.FileName);
            string filePath = Path.Combine(uploadsPath, $"{newFileName}{extension}");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return Path.Combine("images/property", $"{newFileName}{extension}");
        }

    }
}
