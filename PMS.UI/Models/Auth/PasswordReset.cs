using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class PasswordReset
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string ResetToken { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "The password does not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
