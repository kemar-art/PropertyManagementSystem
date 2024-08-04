using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Auth
{
    public class RegisterVM
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "The password does not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [DataType(DataType.Date), Display(Name = "D.O.B")]
        [Required]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
    }
}
