using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.CreateUser;
using Application.Features.Commands.User.UpdateUser;
using AutoMapper;
using Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Persistence.Repository_Implementations;

public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
{
    private static readonly System.Random _random = new();
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly HttpContext _httpContext;

    //private readonly IWebHostEnvironment _hostEnvironment;
    const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
    const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string NUMBERS = "1234567890";
    const string SPECIALS = @"`~!@£$%^&*()[]#€?;+\/<>";

    public UserRepository(PMSDatabaseContext dbContext, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, HttpContext httpContext) : base(dbContext)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _hostEnvironment = hostEnvironment;
        _httpContext = httpContext;
        //_hostEnvironment = hostEnvironment;
    }

    public async Task RegisterAsync(ApplicationUser user)
    {
        ApplicationUser applicationUser = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            TaxRegistrationNumber = user.TaxRegistrationNumber,
            NationalInsuranceScheme = user.NationalInsuranceScheme,
            Gender = user.Gender,
            ImagePath = user.ImagePath,
            DateOfBirth = user.DateOfBirth,
            Datestarted = user.Datestarted
        };

        var password = await RandomPasswordGeneratorAsync();

        var result = await _userManager.CreateAsync(applicationUser, password);
        if (result.Succeeded)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = _httpContext.Request.Form.Files;
            if (files.Any())
            {
                //Create
                string newFileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"wwwroot\images\employees");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                applicationUser.ImagePath = @$"\images\employees\{newFileName}{extension}";
            }
        }
    }


    public async Task<Unit> UpdateUserAsync(UpdateUserCommand user)
    {
        var applicationUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if (applicationUser != null)
        {
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

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = _httpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                string newFileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"wwwroot\images\employees");
                var extension = Path.GetExtension(files[0].FileName);

                if (applicationUser.ImagePath != null)
                {
                    var oldImage = Path.Combine(webRootPath, applicationUser.ImagePath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, newFileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                applicationUser.ImagePath = @$"\images\employees\{newFileName}{extension}";
            }

            await _userManager.UpdateAsync(applicationUser);
            return Unit.Value;
        }

        throw new NotFoundException("User", user.Id);
    }



    private async Task<string> RandomPasswordGeneratorAsync()
    {
        var options = _signInManager.Options.Password;
        var passwordSize = options.RequiredLength = 8;

        string charSet = "";
        if (options.RequireLowercase) charSet += LOWER_CASE;
        if (options.RequireUppercase) charSet += UPPER_CASE;
        if (options.RequireDigit) charSet += NUMBERS;
        if (options.RequireNonAlphanumeric) charSet += SPECIALS;

        char[] _password = new char[passwordSize];

        // Ensure at least one character for each requirement
        _password[0] = LOWER_CASE[_random.Next(LOWER_CASE.Length)];
        if (options.RequireUppercase) _password[1] = UPPER_CASE[_random.Next(UPPER_CASE.Length)];
        if (options.RequireDigit) _password[2] = NUMBERS[_random.Next(NUMBERS.Length)];
        if (options.RequireNonAlphanumeric) _password[3] = SPECIALS[_random.Next(SPECIALS.Length)];

        // Fill the rest of the password with characters from charSet
        for (int i = 4; i < passwordSize; i++)
        {
            _password[i] = charSet[_random.Next(charSet.Length)];
        }

        // Shuffle the password characters to improve randomness
        Shuffle(_password);

        return new string(_password);
    }

    private static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = _random.Next(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}