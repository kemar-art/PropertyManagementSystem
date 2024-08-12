using PMS.UI.Contracts.Repository_Interface;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class NoneLoginResetPassword 
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;
        
        public string ResetToken { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
