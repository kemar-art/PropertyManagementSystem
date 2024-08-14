using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Update;
using Domain;
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

        public ClientRepository(PMSDatabaseContext dbContext, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<ApplicationUser> GetClientById(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null && !string.IsNullOrEmpty(user.ImagePath))
            {
                try
                {
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, user.ImagePath);

                    if (System.IO.File.Exists(filePath))
                    {
                        var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                        var base64String = Convert.ToBase64String(fileBytes);
                        var mimeType = "image/png"; // Adjust MIME type as needed
                        user.ImageBase64 = $"data:{mimeType};base64,{base64String}";
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception if needed
                    Console.WriteLine($"Error converting image to base64: {ex.Message}");
                }
            }

            return user;
        }


        public async Task<Unit> UpdateClient(ClientUpdateCommand updateClient, string imagePath)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == updateClient.Id);
            if (user == null)
            {
                throw new NotFoundException("User", updateClient.Id);
            }

            // Update user properties
            user.FirstName = updateClient.FirstName;
            user.LastName = updateClient.LastName;
            user.Email = updateClient.Email;
            user.PhoneNumber = updateClient.PhoneNumber;
            user.Gender = updateClient.Gender;
            user.DateOfBirth = updateClient.DateOfBirth;
            user.Address = updateClient.Address;
            user.RegionId = updateClient.RegionId;

            IFormFile imageToSave = null;
            MemoryStream stream = null;

            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string base64Data = imagePath.Contains(",") ? imagePath.Split(',')[1] : throw new Exception("Invalid image data format.");

                    string mimeType = "image/png"; // Default to PNG
                    string extension = ".png"; // Default to .png

                    if (imagePath.StartsWith("data:image/jpeg"))
                    {
                        mimeType = "image/jpeg";
                        extension = ".jpg";
                    }
                    else if (imagePath.StartsWith("data:image/png"))
                    {
                        mimeType = "image/png";
                        extension = ".png";
                    }

                    byte[] imageBytes = Convert.FromBase64String(base64Data);
                    stream = new MemoryStream(imageBytes);

                    imageToSave = new FormFile(stream, 0, imageBytes.Length, "file", $"uploadedImage{extension}")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = mimeType
                    };
                }

                if (imageToSave != null && imageToSave.Length > 0)
                {
                    string webRootPath = _hostEnvironment.WebRootPath;
                    string newFileName = Guid.NewGuid().ToString();
                    string uploads = Path.Combine(webRootPath, "images/client");

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    if (!string.IsNullOrEmpty(user.ImagePath))
                    {
                        string oldImage = Path.Combine(webRootPath, user.ImagePath);
                        if (File.Exists(oldImage))
                        {
                            File.Delete(oldImage);
                        }
                    }

                    string filePath = Path.Combine(uploads, $"{newFileName}{Path.GetExtension(imageToSave.FileName)}");

                    // Save the image to the server
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await imageToSave.CopyToAsync(fileStream);

                    // Update the user's image path
                    user.ImagePath = Path.Combine("images/client", $"{newFileName}{Path.GetExtension(imageToSave.FileName)}");
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    throw new Exception($"Failed to update user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Log detailed information
                Console.WriteLine($"An error occurred: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
            finally
            {
                // Dispose of the stream if it was created
                stream?.Dispose();
            }
        }

    }
}

//System.ObjectDisposedException: 'Cannot access a closed Stream.'
