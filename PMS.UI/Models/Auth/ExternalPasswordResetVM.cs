using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class ExternalPasswordResetVM
    {
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "The password does not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
