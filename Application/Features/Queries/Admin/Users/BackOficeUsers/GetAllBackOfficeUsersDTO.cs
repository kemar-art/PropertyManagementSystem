using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.BackOficeUsers
{
    public class GetAllBackOfficeUsersDTO
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public DateTime DateEnded { get; set; } = DateTime.Now;
    }
}
