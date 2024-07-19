using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PMS.UI.Models.Form
{
    public class FormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string InstructionsIssuedBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Property Address")]
        public string PropertyAddress { get; set; } = string.Empty;

        public string Direction { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        public string Volume { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        public string Folio { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Starter Plan")]
        public string StrataPlan { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Is Key Available")]
        public bool? IsKeyAvailable { get; set; } 

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mortgage Institution")]
        public string MortgageInstitution { get; set; } = string.Empty;

        public string Other { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string SecondaryContactFirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string SecondaryContactLastName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string SecondaryContactEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Reason for Cancel")]
        public string ReasonForCancel { get; set; } = string.Empty;

        [Display(Name = "Admin Note")]
        public string AdminNote { get; set; } = string.Empty;

        [Display(Name = "Appraiser Note")]
        public string AppraiserNote { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ValuationRequiredBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateFormWasFilledOut { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FromAssigned { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FromAccepted { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FormInProcess { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime RejectedForm { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime MarkFromAsCompleted { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReturnFromToAppraiser { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime SubmittedFormForApproval { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CancelledForm { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ApprovedForm { get; set; }

        [ForeignKey("RegionId")]
        public Region? Region { get; set; }
        public Guid? RegionId { get; set; }

        public List<FormTypeOfPropertyItem>? ServiceRequesFormTypeOfPropertyItem { get; set; }

        public List<FormServiceRequestItem>? ServiceRequestFormServiceRequestItem { get; set; }

        public List<FormPurposeOfValuationItem>? ServiceRequestFormPurposeOfValuationItem { get; set; }
    }
}
