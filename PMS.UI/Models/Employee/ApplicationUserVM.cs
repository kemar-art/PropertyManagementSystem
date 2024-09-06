using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Employee
{
    public class ApplicationUserVM
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        
        public DateTime? DateRegistered { get; set; } = DateTime.Now;

      
        public DateTime? DateEnded { get; set; } = DateTime.Now;

        public string Role { get; set; } = string.Empty;

        //public bool IsActive { get; set; } = true;


        //[ForeignKey("RegionId")]
        //public Region? Region { get; set; }
        //public Guid? RegionId { get; set; }


        //[ForeignKey("JobTitleId")]
        //public JobTitle? JobTitle { get; set; }
        //public Guid? JobTitleId { get; set; }
    }
}
