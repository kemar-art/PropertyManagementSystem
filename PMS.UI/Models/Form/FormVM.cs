using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PMS.UI.Models.Form
{
    public class FormVM
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string InstructionsIssuedBy { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Property Address")]
        public string PropertyAddress { get; set; } = string.Empty;

        public string PropertyDirection { get; set; } = string.Empty;

        [Required]
        public string Volume { get; set; } = string.Empty;

        [Required]
        public string Folio { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Strata Plan")]
        public string StrataPlan { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Key")]
        public string IsKeyAvailable { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mortgage Institution")]
        public string MortgageInstitution { get; set; } = string.Empty;

        public string Other { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First Name")]
        public string SecondaryContactFirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string SecondaryContactLastName { get; set; } = string.Empty;

        public string SecondaryContactEmail { get; set; } = string.Empty;

        [Required]
        public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

        [ForeignKey("RegionId")]
        public Region? Region { get; set; }
        public Guid RegionId { get; set; }


        public string TypeOfPropertySelectedIds { get; set; } = string.Empty;
        public string ServiceRequestItemSelectId { get; set; } = string.Empty;
        public string PurposeOfValuationItemSelectedIds { get; set; } = string.Empty;

        public bool Exists { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public string ServiceRequestValidationMessage { get; set; } = string.Empty;
        public string TypeOfPropertyValidationMessage { get; set; } = string.Empty;
        public string PurposeOfEvaluationValidationMessage { get; set; } = string.Empty;
    }
}

