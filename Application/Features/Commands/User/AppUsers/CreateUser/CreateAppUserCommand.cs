﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.AppUsers.CreateUser
{
    public class CreateAppUserCommand : IRequest<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }

        [DataType(DataType.Date), Display(Name = "D.O.B")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;


        //public string Role { get; set; } = string.Empty;

        //public SelectList RolesList { get; set; }
    }
}
