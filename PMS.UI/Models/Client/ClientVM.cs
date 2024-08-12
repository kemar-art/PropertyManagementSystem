using Microsoft.AspNetCore.Http;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Client
{
    public class ClientVM
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }


}