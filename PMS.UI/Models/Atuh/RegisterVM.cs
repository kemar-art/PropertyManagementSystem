using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Atuh
{
    public class RegisterVM
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //[Required]
        //[Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date), Display(Name = "D.O.B")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
