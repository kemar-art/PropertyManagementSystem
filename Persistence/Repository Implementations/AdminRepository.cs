using Application.Contracts.Email;
using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Persistence.DatabaseContext;
using Persistence.SeedConfig.UserRole;
using Application.StaticDetails;
using Application.Contracts.ILogging;
using Application.Features.Commands.Admin.AssignForm;

namespace Persistence.Repository_Implementations
{
    public class AdminRepository : GenericRepository<ApplicationUser>, IAdminRepository
    {
        private static readonly System.Random _random = new();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<AdminRepository> _appLogger;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "1234567890";
        const string SPECIALS = @"`~!@£$%^&*()[]#€?;+<>";

        public AdminRepository(
            PMSDatabaseContext dbContext,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender,
            IAppLogger<AdminRepository> appLogger)
            : base(dbContext)
        {
            _userManager = userManager; 
            _hostEnvironment = hostEnvironment; //?? throw new ArgumentNullException(nameof(hostEnvironment));
            _httpContextAccessor = httpContextAccessor; //?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userStore = userStore; //?? throw new ArgumentNullException(nameof(userStore));
            _emailSender = emailSender; //?? throw new ArgumentNullException(nameof(emailSender));
            _appLogger = appLogger;
            _emailStore = (IUserEmailStore<ApplicationUser>)userStore; //?? throw new ArgumentNullException(nameof(userStore));
        }

        public async Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser)
        {
            var formToAssigned = await _dbContext.Forms.FirstOrDefaultAsync(f => f.Id == assignFormToAppraiser.FormId);
            if (formToAssigned != null)
            {
                // Fetch the user ID using the correct claim type
                var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
                if (userId == null)
                {
                    _appLogger.LogError("User not found in the claims.");
                    throw new NotFoundException("User not found.", userId);
                }

                // Verify that the JobAssignerId exists 
                var jobAssignerExists = await _userManager.FindByIdAsync(userId);
                if (jobAssignerExists == null)
                {
                    _appLogger.LogError($"The Job Assigner Id {userId} does not exist in the AspNetUsers table.");
                    throw new NotFoundException("The Job Assigner Id does not exist.", userId);
                }

                // Verify that the AppraiserId exists 
                var appraiserExists = await _userManager.FindByIdAsync(assignFormToAppraiser.AppraiserId);
                if (appraiserExists == null)
                {
                    _appLogger.LogError($"The Appraiser Id {assignFormToAppraiser.AppraiserId} does not exist in the AspNetUsers table.");
                    throw new NotFoundException("The Appraiser Id does not exist in the AspNetUsers table.", userId);
                }

                formToAssigned.AppraiserId = assignFormToAppraiser.AppraiserId;
                formToAssigned.JobAssignerId = userId;
                formToAssigned.AdminNote = assignFormToAppraiser.AdminNote;
                formToAssigned.Status = FormStatus.StatusAssigned;

                try
                {
                    _dbContext.Update(formToAssigned);
                    await _dbContext.SaveChangesAsync();

                    FormInteractionLog interactionLog = new()
                    {
                        FormId = formToAssigned.Id,
                        ApplicationUserId = formToAssigned.AppraiserId,
                        Status = formToAssigned.Status,
                        LastUpdated = DateTime.Now,
                        AppraiserNote = formToAssigned.AppraiserNote
                    };
                    await _dbContext.AddAsync(interactionLog);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation("Form successfully updated.");
                    return Unit.Value;
                }
                catch (DbUpdateException ex)
                {
                    _appLogger.LogError("An error occurred while saving changes.", ex);
                    throw new Exception("An error occurred while saving changes. Please try again later.", ex);
                }
            }

            _appLogger.LogError($"The form with Id {assignFormToAppraiser.FormId} was not found.");
            throw new NotFoundException("The form was not found with the Id value:", formToAssigned.Id);
        }

        public async Task<IEnumerable<Form>> GetFormByStatusForAdmin(string status)
        {
            return await _dbContext.Forms
                                        //.Include(x => x.Region)
                                        .Where(x => x.Status == status)
                                        .Include(x => x.Appraiser)
                                        //.Include(x => x.ServiceRequestFormServiceRequestItem)
                                        //.ThenInclude(x => x.ServiceRequestItem)
                                        //.Include(x => x.ServiceRequesFormTypeOfPropertyItem)
                                        //.ThenInclude(x => x.TypeOfPropertyItem)
                                        //.Include(x => x.ServiceRequestFormPurposeOfValuationItem)
                                        //.ThenInclude(x => x.PurposeOfValuationItem)
                                        .ToListAsync();
        }

        public async Task<string> RegisterAppUserAsync(CreateAppUserCommand user, IFormFile image)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                TaxRegistrationNumber = user.TaxRegistrationNumber,
                NationalInsuranceScheme = user.NationalInsuranceScheme,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                DateRegistered = DateTime.Now,
                EmailConfirmed = true,
                Role = Roles.Administrator,
            };  

            await _userStore.SetUserNameAsync(applicationUser, user.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(applicationUser, user.Email, CancellationToken.None);

            var password = await GenerateRandomPasswordAsync();
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                if (image != null && image.Length > 0)
                {
                    string webRootPath = _hostEnvironment.WebRootPath;
                    string newFileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, "images/employees");
                    var extension = Path.GetExtension(image.FileName);

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    using var fileStream = new FileStream(Path.Combine(uploads, $"{newFileName}{extension}"), FileMode.Create);
                    image.CopyTo(fileStream);

                    applicationUser.ImagePath = Path.Combine("images/employees", $"{newFileName}{extension}");
                }

                await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);
                var userId = await _userManager.GetUserIdAsync(applicationUser);
                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                var emailConfirmation = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/Identity/Account/ConfirmEmail?userId={applicationUser.Id}&code={code}";

                await _emailSender.VerificationEmail(applicationUser.Email, emailConfirmation);
                await _emailSender.PasswordGeneratorEmail(applicationUser.Email, password);

                return applicationUser.Id;
            }

            throw new Exception("User registration failed");
        }

        public async Task<Unit> UpdateAppUserAsync(UpdateAppUserCommand user, IFormFile image)
        {
            var applicationUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (applicationUser == null)
            {
                throw new NotFoundException("User", user.Id);
            }

            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.Address = user.Address;
            applicationUser.Email = user.Email;
            applicationUser.PhoneNumber = user.PhoneNumber;
            applicationUser.TaxRegistrationNumber = user.TaxRegistrationNumber;
            applicationUser.NationalInsuranceScheme = user.NationalInsuranceScheme;
            applicationUser.Gender = user.Gender;
            applicationUser.UserName = user.Email;
            applicationUser.DateOfBirth = user.DateOfBirth;
            applicationUser.DateRegistered = user.Datestarted;
            applicationUser.Role = Roles.Administrator;


            if (image != null && image.Length > 0)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                string newFileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, "images/employees");
                var extension = Path.GetExtension(image.FileName);


                if (!string.IsNullOrEmpty(applicationUser.ImagePath))
                {
                    var oldImage = Path.Combine(webRootPath, applicationUser.ImagePath);
                    if (File.Exists(oldImage))
                    {
                        File.Delete(oldImage);
                    }
                }

                using var fileStream = new FileStream(Path.Combine(uploads, $"{newFileName}{extension}"), FileMode.Create);
                image.CopyTo(fileStream);

                applicationUser.ImagePath = Path.Combine("images/employees", $"{newFileName}{extension}");
            }

            await _userManager.UpdateAsync(applicationUser);
            await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);

            return Unit.Value;
        }

        public async Task<Unit> MarkFormHasComplete(Guid? formId, string? appraiserId)
        {
            if (formId == null)
            {
                _appLogger.LogWarning("Form ID is null.");
                throw new ArgumentNullException(nameof(formId), "Form ID cannot be null.");
            }

            if (string.IsNullOrEmpty(appraiserId))
            {
                _appLogger.LogWarning("Appraiser ID is null or empty.");
                throw new ArgumentNullException(nameof(appraiserId), "Appraiser ID cannot be null or empty.");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;

            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to mark form with ID {formId} as complete for appraiser {appraiserId} by user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == formId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {formId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {formId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == appraiserId)
                {
                    _appLogger.LogInformation($"Appraiser {appraiserId} is the assigned appraiser for form {formId}. Marking form as complete...");

                    formFromDb.Status = FormStatus.StatusCompleted;
                    formFromDb.DateCompleted = DateTime.Now;

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

                    _appLogger.LogInformation($"Form with ID {formId} marked as complete successfully by appraiser {appraiserId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"Appraiser {appraiserId} is not the assigned appraiser for form {formId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while marking form {formId} as complete for appraiser {appraiserId} by user {userId}.", ex); 
            }

            throw new BadHttpRequestException("An error occurred while marking this job as complete. Please refresh and try again.");
        }

        public async Task<Unit> ReturnTheFormToAppraiserForCompletion(Guid? returnFormToAppraiser)
        {
            if (returnFormToAppraiser == null)
            {
                _appLogger.LogWarning("Form ID is null.");
                throw new ArgumentNullException(nameof(returnFormToAppraiser), "Form ID cannot be null.");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to return form with ID {returnFormToAppraiser} to appraiser for completion by user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == returnFormToAppraiser);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {returnFormToAppraiser} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {returnFormToAppraiser} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {returnFormToAppraiser}. Returning form for completion...");

                    formFromDb.Status = FormStatus.StatusReturnToAppraiser;
                    formFromDb.DateReturnToAppraiser = DateTime.Now;

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

                    _appLogger.LogInformation($"Form with ID {returnFormToAppraiser} returned to appraiser for completion successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {returnFormToAppraiser}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while returning form {returnFormToAppraiser} to appraiser for completion by user {userId}.", ex);
            }

            throw new BadHttpRequestException("An error occurred while returning this job for completion. Please refresh and try again.");
        }

        private async Task<string> GenerateRandomPasswordAsync()
        {
            var options = _userManager.Options.Password;
            var passwordSize = options.RequiredLength;

            var charSet = new StringBuilder();
            if (options.RequireLowercase) charSet.Append(LOWER_CASE);
            if (options.RequireUppercase) charSet.Append(UPPER_CASE);
            if (options.RequireDigit) charSet.Append(NUMBERS);
            if (options.RequireNonAlphanumeric) charSet.Append(SPECIALS);

            var password = new char[passwordSize];
            password[0] = LOWER_CASE[_random.Next(LOWER_CASE.Length)];
            if (options.RequireUppercase) password[1] = UPPER_CASE[_random.Next(UPPER_CASE.Length)];
            if (options.RequireDigit) password[2] = NUMBERS[_random.Next(NUMBERS.Length)];
            if (options.RequireNonAlphanumeric) password[3] = SPECIALS[_random.Next(SPECIALS.Length)];

            for (int i = 4; i < passwordSize; i++)
            {
                password[i] = charSet[_random.Next(charSet.Length)];
            }

            Shuffle(password);

            return new string(password);
        }

        private static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}
