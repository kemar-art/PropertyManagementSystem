﻿using Application.Contracts.Email;
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
using Persistence.SeedConfig;
using static System.Net.Mime.MediaTypeNames;

namespace Persistence.Repository_Implementations
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private static readonly System.Random _random = new();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailSender _emailSender;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "1234567890";
        const string SPECIALS = @"`~!@£$%^&*()[]#€?;+\/<>";

        public UserRepository(
            PMSDatabaseContext dbContext,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment hostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender)
            : base(dbContext)
        {
            _userManager = userManager; //?? throw new ArgumentNullException(nameof(userManager));
            _hostEnvironment = hostEnvironment; //?? throw new ArgumentNullException(nameof(hostEnvironment));
            _httpContextAccessor = httpContextAccessor; //?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userStore = userStore; //?? throw new ArgumentNullException(nameof(userStore));
            _emailSender = emailSender; //?? throw new ArgumentNullException(nameof(emailSender));
            _emailStore = (IUserEmailStore<ApplicationUser>)userStore; //?? throw new ArgumentNullException(nameof(userStore));
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
                Datestarted = user.Datestarted,
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
                //var userId = await _userManager.GetUserIdAsync(applicationUser);
                //var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                //string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                //var emailConfirmation = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/Identity/Account/ConfirmEmail?userId={applicationUser.Id}&code={code}";

                //await _emailSender.VerificationEmail(applicationUser.Email, emailConfirmation);
                //await _emailSender.PasswordGeneratorEmail(applicationUser.Email, password);

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
            applicationUser.Datestarted = user.Datestarted;


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
            //await _userManager.AddToRoleAsync(applicationUser, user.RoleId);

            return Unit.Value;
        }

        public async Task<string> RegisterClientUserAsync(ClientUserCommand user)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
            };

            var result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Client user registration failed");
            }

            var role = string.IsNullOrEmpty(user.Role) ? Roles.Client : user.Role;
            await _userManager.AddToRoleAsync(applicationUser, role);

            return applicationUser.Id;
        }

        public async Task<Unit> LogInUserAsync(LoginUsersCommand user)
        {
            var findUserByEmail = await _userManager.FindByEmailAsync(user.Email);
            if (findUserByEmail == null || !await _userManager.CheckPasswordAsync(findUserByEmail, user.Password))
            {
                throw new NotFoundException("User", user.Email);
            }

            return Unit.Value;
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
