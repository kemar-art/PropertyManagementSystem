using PMS.UI.Contracts.Repository_Interface;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class LoginUserPasswordReset
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
