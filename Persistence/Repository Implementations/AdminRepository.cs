using Application.Contracts.Email;
using Application.Contracts.Repository_Interface;
using Application.Exceptions;
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
using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.BackOfficeUsers.CreateUser;
using Domain.Common;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.AspNetCore.Rewrite;
using AutoMapper;
using Application.Features.Queries.Admin.Users.BackOficeUsers;
using Application.Features.Queries.Admin.Users.ClientUsers;
using Application.Features.Commands.User.BackOfficeUsers.DeleteUser;
using Microsoft.AspNetCore.Http.HttpResults;

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
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAppLogger<AdminRepository> _appLogger;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public AdminRepository(
            PMSDatabaseContext dbContext,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            IAppLogger<AdminRepository> appLogger)
            : base(dbContext)
        {
            _userManager = userManager;
            _hostEnvironment = hostEnvironment; //?? throw new ArgumentNullException(nameof(hostEnvironment));
            _httpContextAccessor = httpContextAccessor; //?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userStore = userStore; //?? throw new ArgumentNullException(nameof(userStore));
            _emailSender = emailSender; //?? throw new ArgumentNullException(nameof(emailSender));
            _mapper = mapper;
            _roleManager = roleManager;
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
                                        .Include(x => x.PropertyRegion)
                                        .Where(x => x.Status == status)
                                        .Include(x => x.Appraiser)
                                        .OrderBy(x => x.CustomerId)
                                        .ToListAsync();
        }

        public async Task<BaseResult<CustomResponse>> RegisterAdminUserAsync(CreateBackOfficeUserCommand user, string imagePath)
        {
            ApplicationUser applicationUser = new();
            try
            {
                _appLogger.LogInformation($"Registering Back Office User: {user.FirstName} {user.LastName}");

                applicationUser.FirstName = user.FirstName;
                applicationUser.LastName = user.LastName;
                applicationUser.Email = user.Email;
                applicationUser.Address = user.Address;
                applicationUser.PhoneNumber = user.PhoneNumber;
                applicationUser.TaxRegistrationNumber = user.TaxRegistrationNumber;
                applicationUser.NationalInsuranceScheme = user.NationalInsuranceScheme;
                applicationUser.Gender = user.Gender;
                applicationUser.DateOfBirth = user.DateOfBirth;
                applicationUser.DateRegistered = user.DateRegistered;
                applicationUser.EmailConfirmed = true;
                //applicationUser.Role = Roles.Administrator;

                await _userStore.SetUserNameAsync(applicationUser, user.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(applicationUser, user.Email, CancellationToken.None);

                var password = await GenerateRandomPasswordAsync();
                var result = await _userManager.CreateAsync(applicationUser, password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        var imageToSave = ConvertBase64ToFormFile(imagePath);
                        if (imageToSave != null)
                        {
                            var imageSaved = await SaveClientImageAsync(user, imageToSave);
                            if (!imageSaved)
                            {
                                _appLogger.LogError("Image saving failed.");
                                return BaseResult<CustomResponse>.Failure("Image saving failed.");
                            }
                        }
                        else
                        {
                            _appLogger.LogError("Failed to convert image data.");
                            return BaseResult<CustomResponse>.Failure("Failed to convert image data.");
                        }
                    }

                    var role = await _roleManager.FindByIdAsync(user.RoleId);
                    if (role == null)
                    {
                        _appLogger.LogError($"Role with ID {user.RoleId} does not exist.");
                        return BaseResult<CustomResponse>.Failure($"Role with ID {user.RoleId} does not exist.");
                    }


                    var roleExists = await _roleManager.RoleExistsAsync(role.Name);
                    if (!roleExists)
                    {
                        _appLogger.LogError($"Role {user.RoleId} does not exist.");
                        return BaseResult<CustomResponse>.Failure($"Role {user.RoleId} does not exist.");
                    }




                    await _userManager.AddToRoleAsync(applicationUser, role.Name);



                    var userId = await _userManager.GetUserIdAsync(applicationUser);
                    var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                    string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                    var emailConfirmation = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/Identity/Account/ConfirmEmail?userId={applicationUser.Id}&code={code}";

                    await _emailSender.VerificationEmail(applicationUser.Email, emailConfirmation);
                    await _emailSender.PasswordGeneratorEmail(applicationUser.Email, password);

                    _appLogger.LogInformation($"User with ID {applicationUser.Id} register successfully.");

                    // Return success with the user Id
                    return BaseResult<CustomResponse>.Success(new CustomResponse { Message = "User Register successfully " }, new Guid(applicationUser.Id));
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An unexpected error occurred while registering user with ID {applicationUser.Id}. Exception: {ex.Message}");
                return BaseResult<CustomResponse>.Failure($"An unexpected error occurred while registering user: {ex.Message}");
            }

            return BaseResult<CustomResponse>.Failure("User registration failed");
        }

        public async Task<BaseResult<CustomResponse>> UpdateAppUserAsync(UpdateBackOfficeUserCommand user, string imagePath)
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
            applicationUser.DateRegistered = user.DateRegistered;




            var role = await _roleManager.FindByIdAsync(user.RoleId);
            if (role == null)
            {
                _appLogger.LogError($"Role with ID {user.RoleId} does not exist.");
                return BaseResult<CustomResponse>.Failure($"Role with ID {user.RoleId} does not exist.");
            }


            var roleExists = await _roleManager.RoleExistsAsync(role.Name);
            if (!roleExists)
            {
                _appLogger.LogError($"Role {user.RoleId} does not exist.");
                return BaseResult<CustomResponse>.Failure($"Role {user.RoleId} does not exist.");
            }


            var result = await _userManager.UpdateAsync(applicationUser);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    var imageToSave = ConvertBase64ToFormFile(imagePath);
                    if (imageToSave != null)
                    {
                        var imageSaved = await SaveClientImageAsync(user, imageToSave);
                        if (!imageSaved)
                        {
                            _appLogger.LogError("Image saving failed.");
                            return BaseResult<CustomResponse>.Failure("Image saving failed.");
                        }
                    }
                    else
                    {
                        _appLogger.LogError("Failed to convert image data.");
                        return BaseResult<CustomResponse>.Failure("Failed to convert image data.");
                    }
                }

               






                await _userManager.AddToRoleAsync(applicationUser, role.Name);


                _appLogger.LogInformation($"User with ID {applicationUser.Id} register successfully.");

                // Return success with the user Id
                return BaseResult<CustomResponse>.Success(new CustomResponse { Message = "User Register successfully " }, new Guid(applicationUser.Id));
            }






            //await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);

            return BaseResult<CustomResponse>.Failure("Failed To Update User");
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

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.Where(r => r.Name != Roles.Client).ToListAsync();
        }

        public async Task<IEnumerable<GetAllBackOfficeUsersDTO>> GetAllBackOfficeUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            // Filter users who are not in the "Client" role
            var nonClientUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains(Roles.Client))
                {
                    nonClientUsers.Add(user);
                }
            }

            var backOfficeUsers = _mapper.Map<IEnumerable<GetAllBackOfficeUsersDTO>>(nonClientUsers);

            return backOfficeUsers;
        }

        public async Task<IEnumerable<GetAllClientUsersDTO>> GetAllClientUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var nonBackOfficeUsers = new List<ApplicationUser>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains(Roles.Client))
                {
                    nonBackOfficeUsers.Add(user);
                }
            }

            var clientUsers = _mapper.Map<IEnumerable<GetAllClientUsersDTO>>(nonBackOfficeUsers);

            return clientUsers;
        }

        private FormFile ConvertBase64ToFormFile(string base64ImageData)
        {
            try
            {
                string base64Data = base64ImageData.Contains(",") ? base64ImageData.Split(',')[1] : throw new Exception("Invalid image data format.");

                string mimeType = base64ImageData.StartsWith("data:image/jpeg", StringComparison.OrdinalIgnoreCase) ? "image/jpeg" : "image/png";
                string extension = mimeType == "image/jpeg" ? ".jpg" : ".png";

                byte[] imageBytes = Convert.FromBase64String(base64Data);
                var stream = new MemoryStream(imageBytes);

                return new FormFile(stream, 0, imageBytes.Length, "file", $"uploadedImage{extension}")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = mimeType
                };
            }
            catch (Exception ex)
            {
                _appLogger.LogError("Error converting base64 image data to FormFile. Exception: " + ex.Message);
                return null; // Return null if conversion fails
            }
        }

        private async Task<bool> SaveClientImageAsync(CreateBackOfficeUserCommand user, IFormFile imageToSave)
        {
            try
            {
                if (imageToSave == null || imageToSave.Length == 0)
                {
                    return true; // No image to save, return success
                }

                string webRootPath = _hostEnvironment.WebRootPath;
                string uploads = Path.Combine(webRootPath, "images/admins");
                string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageToSave.FileName)}";
                string newFilePath = Path.Combine(uploads, newFileName);

                // Ensure the uploads directory exists
                Directory.CreateDirectory(uploads);

                // Delete old image if it exists
                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    string oldImagePath = Path.Combine(webRootPath, user.ImagePath);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // Save the new image
                using var fileStream = new FileStream(newFilePath, FileMode.Create);
                await imageToSave.CopyToAsync(fileStream);

                // Update the user's image path
                user.ImagePath = Path.Combine("images/client", newFileName);

                return true;
            }
            catch (Exception ex)
            {
                _appLogger.LogError("Error saving user image. Exception: " + ex.Message);
                return false;
            }
        }

        private async Task<string> GenerateRandomPasswordAsync()
        {
            var options = _userManager.Options.Password;
            var passwordSize = options.RequiredLength;

            var charSet = new StringBuilder();
            if (options.RequireLowercase) charSet.Append(RandomPasswordCharSets.LOWER_CASE);
            if (options.RequireUppercase) charSet.Append(RandomPasswordCharSets.UPPER_CASE);
            if (options.RequireDigit) charSet.Append(RandomPasswordCharSets.NUMBERS);
            if (options.RequireNonAlphanumeric) charSet.Append(RandomPasswordCharSets.SPECIALS);

            var password = new char[passwordSize];
            password[0] = RandomPasswordCharSets.LOWER_CASE[_random.Next(RandomPasswordCharSets.LOWER_CASE.Length)];
            if (options.RequireUppercase) password[1] = RandomPasswordCharSets.UPPER_CASE[_random.Next(RandomPasswordCharSets.UPPER_CASE.Length)];
            if (options.RequireDigit) password[2] = RandomPasswordCharSets.NUMBERS[_random.Next(RandomPasswordCharSets.NUMBERS.Length)];
            if (options.RequireNonAlphanumeric) password[3] = RandomPasswordCharSets.SPECIALS[_random.Next(RandomPasswordCharSets.SPECIALS.Length)];

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

        public async Task<CustomResponse> DeleteAllUsers(string userId)
        {
            // Find the form to be deleted
            var userToDelete = await _userManager.FindByIdAsync(userId);
            if (userToDelete != null)
            {
                await _userManager.DeleteAsync(userToDelete);
                await _dbContext.SaveChangesAsync();

                return new CustomResponse { IsSuccess = true, Message = "Record Deleted Successfully." };
            }

            // Throw an exception if the user is not found
            throw new NotFoundException(nameof(DeleteAppUserCommand), userId);
        }




        private async Task<bool> SaveClientImageAsync(UpdateBackOfficeUserCommand user, IFormFile imageToSave)
        {
            try
            {
                if (imageToSave == null || imageToSave.Length == 0)
                {
                    return true; // No image to save, return success
                }

                string webRootPath = _hostEnvironment.WebRootPath;
                string uploads = Path.Combine(webRootPath, "images/admins");
                string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageToSave.FileName)}";
                string newFilePath = Path.Combine(uploads, newFileName);

                // Ensure the uploads directory exists
                Directory.CreateDirectory(uploads);

                // Delete old image if it exists
                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    string oldImagePath = Path.Combine(webRootPath, user.ImagePath);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // Save the new image
                using var fileStream = new FileStream(newFilePath, FileMode.Create);
                await imageToSave.CopyToAsync(fileStream);

                // Update the user's image path
                user.ImagePath = Path.Combine("images/client", newFileName);

                return true;
            }
            catch (Exception ex)
            {
                _appLogger.LogError("Error saving user image. Exception: " + ex.Message);
                return false;
            }
        }
    }
}
