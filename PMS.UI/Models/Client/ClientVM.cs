using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Client
{
    public class ClientVM
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        //public DateTime DateOfBirth { get; set; }= DateTime.Now;

        [Required]
        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}