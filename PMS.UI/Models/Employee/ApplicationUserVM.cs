using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.UI.Models.Employee
{
    public class ApplicationUserVM
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        [Required]
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;
        //public string Role { get; set; } = string.Empty;

        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public DateTime? DateRegistered { get; set; } 
        public DateTime? DateEnded { get; set; }



        //public bool IsActive { get; set; } = true;

        public string RoleId { get; set; } = string.Empty;


        [ForeignKey("AdminRegionId")]
        public Region? AdminRegion { get; set; }
        public Guid AdminRegionId { get; set; }


        //[ForeignKey("JobTitleId")]
        //public JobTitle? JobTitle { get; set; }
        //public Guid? JobTitleId { get; set; }
    }
}
