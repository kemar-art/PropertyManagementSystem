using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Features.Commands.User.AppUsers.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        //public IFormFile? Image { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Date), Display(Name = "D.O.B")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date), Display(Name = "Start Date")]
        public DateTime Datestarted { get; set; } = DateTime.Now;

        [Display(Name = "Access Privilege")]
        public string RoleId { get; set; }
        [Display(Name = "Role")]
        public SelectList RolesList { get; set; }
    }
}
