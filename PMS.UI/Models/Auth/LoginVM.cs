using PMS.UI.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Atuh
{
    public class LoginVM
    {
        [Required]
        [EmailContainsAtSign]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
