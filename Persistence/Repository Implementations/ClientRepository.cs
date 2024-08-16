using Application.Contracts.ILogging;
using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Update;
using Domain;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.FileIO;
using Persistence.DatabaseContext;
using Persistence.SeedConfig.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly PMSDatabaseContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IAppLogger<ClientRepository> _appLogger;

        public ClientRepository(PMSDatabaseContext dbContext, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, IAppLogger<ClientRepository> appLogger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
            _appLogger = appLogger;
        }

        public async Task<ApplicationUser> GetClientById(string userId)
        {
            try
            {
                _appLogger.LogInformation($"Retrieving user with ID {userId}.");

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    _appLogger.LogWarning($"User with ID {userId} was not found.");
                    return null; // or throw an exception, depending on your needs
                }

                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    try
                    {
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, user.ImagePath);

                        if (System.IO.File.Exists(filePath))
                        {
                            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                            var base64String = Convert.ToBase64String(fileBytes);

                            // Determine MIME type based on file extension
                            string mimeType = user.ImagePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ? "image/png" : "image/jpeg";

                            user.ImageBase64 = $"data:{mimeType};base64,{base64String}";

                            _appLogger.LogInformation($"Successfully converted image to base64 for user {userId}.");
                        }
                        else
                        {
                            _appLogger.LogWarning($"Image file not found at {filePath} for user {userId}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _appLogger.LogError($"Error converting image to base64 for user {userId}.", ex);
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while retrieving the user with ID {userId}.", ex);
                return null; // or a default ApplicationUser object if needed
            }
        }

        public async Task<BaseResult<Unit>> UpdateClient(ClientUpdateCommand updateClient, string imagePath)
        {
            try
            {
                _appLogger.LogInformation($"Attempting to update user with ID {updateClient.Id}.");

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == updateClient.Id);
                if (user == null)
                {
                    _appLogger.LogWarning($"User with ID {updateClient.Id} not found.");
                    return BaseResult<Unit>.Failure($"User with ID {updateClient.Id} not found.");
                }

                // Update user properties
                UpdateClientProperties(user, updateClient);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    var imageToSave = ConvertBase64ToFormFile(imagePath);
                    if (imageToSave != null)
                    {
                        var imageSaved = await SaveClientImageAsync(user, imageToSave);
                        if (!imageSaved)
                        {
                            _appLogger.LogError("Image saving failed.");
                            return BaseResult<Unit>.Failure("Image saving failed.");
                        }
                    }
                    else
                    {
                        _appLogger.LogError("Failed to convert image data.");
                        return BaseResult<Unit>.Failure("Failed to convert image data.");
                    }
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    var errorMessage = $"Failed to update user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}";
                    _appLogger.LogError(errorMessage);
                    return BaseResult<Unit>.Failure(errorMessage);
                }

                _appLogger.LogInformation($"User with ID {updateClient.Id} updated successfully.");
                return BaseResult<Unit>.Success(Unit.Value); // Indicate successful completion
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An unexpected error occurred while updating user with ID {updateClient.Id}. Exception: {ex.Message}");
                return BaseResult<Unit>.Failure($"An unexpected error occurred: {ex.Message}");
            }
        }

        private void UpdateClientProperties(ApplicationUser user, ClientUpdateCommand updateClient)
        {
            user.FirstName = updateClient.FirstName;
            user.LastName = updateClient.LastName;
            user.Email = updateClient.Email;
            user.PhoneNumber = updateClient.PhoneNumber;
            user.Gender = updateClient.Gender;
            user.DateOfBirth = updateClient.DateOfBirth;
            user.Address = updateClient.Address;
            user.ClientRegionId = updateClient.ClientRegionId;
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

        private async Task<bool> SaveClientImageAsync(ApplicationUser user, IFormFile imageToSave)
        {
            try
            {
                if (imageToSave == null || imageToSave.Length == 0)
                {
                    return true; // No image to save, return success
                }

                string webRootPath = _hostEnvironment.WebRootPath;
                string uploads = Path.Combine(webRootPath, "images/client");
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

//System.ObjectDisposedException: 'Cannot access a closed Stream.'
