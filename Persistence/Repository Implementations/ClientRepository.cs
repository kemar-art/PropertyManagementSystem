using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Update;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

        public async Task<Unit> UpdateClient(ClientUpdateCommand updateClient, IFormFile image)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == updateClient.Id);
            if (user == null)
            {
                throw new NotFoundException("User", user.Id);
            }

            user.FirstName = updateClient.FirstName;
            user.LastName = updateClient.LastName;
            user.Email = updateClient.Email;
            user.PhoneNumber = updateClient.PhoneNumber;
            user.Gender = updateClient.Gender;
            user.DateOfBirth = updateClient.DateOfBirth;

            if (image != null && image.Length > 0)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                string newFileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, "images/client");
                var extension = Path.GetExtension(image.FileName);


                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    var oldImage = Path.Combine(webRootPath, user.ImagePath);
                    if (File.Exists(oldImage))
                    {
                        File.Delete(oldImage);
                    }
                }

                using var fileStream = new FileStream(Path.Combine(uploads, $"{newFileName}{extension}"), FileMode.Create);
                image.CopyTo(fileStream);

                user.ImagePath = Path.Combine("images/client", $"{newFileName}{extension}");
            }
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
