using PMS.UI.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class ForgetPassword
    {
        [Required]
        [EmailContainsAtSign]
        public string Email { get; set; } = string.Empty;

       
    }
}
