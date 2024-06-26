using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        public string NationalInsuranceScheme { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        [DataType(DataType.Date), Display(Name = ("D.O.B"))]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date), Display(Name = ("Start Date"))]
        public DateTime Datestarted { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime DateEnded { get; set; } = DateTime.Now;

        public string RoleId { get; set; }

        //public bool IsActive { get; set; } = true;


        //[ForeignKey("RegionId")]
        //public Region? Region { get; set; }
        //public Guid? RegionId { get; set; }


        //[ForeignKey("JobTitleId")]
        //public JobTitle? JobTitle { get; set; }
        //public Guid? JobTitleId { get; set; }
    }
}
