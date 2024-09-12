using Domain;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.BackOfficeUsers.CreateUser
{
    public class CreateBackOfficeUserCommand : IRequest<BaseResult<CustomResponse>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;

        public string ImageBase64 { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateRegistered { get; set; }
        public DateTime? DateEnded { get; set; }


        public string RoleId { get; set; } = string.Empty;
        //public bool IsActive { get; set; } = true;


        [ForeignKey("AdminRegionId")]
        public Region? AdminRegion { get; set; }
        public Guid? AdminRegionId { get; set; }

        //public string Role { get; set; } = string.Empty;

        //public SelectList RolesList { get; set; }
    }
}
