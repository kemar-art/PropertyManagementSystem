
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Form
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();  

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string InstructionsIssuedBy { get; set; } = string.Empty;

    public string PropertyAddress { get; set; } = string.Empty;

    public string PropertyDirection { get; set; } = string.Empty;

    public string Volume { get; set; } = string.Empty;

    public string Folio { get; set; } = string.Empty;

    public string StrataPlan { get; set; } = string.Empty;

    public string IsKeyAvailable { get; set; } = string.Empty;

    public string MortgageInstitution { get; set; } = string.Empty;

    public string Other { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string SecondaryContactName { get; set; } = string.Empty;

    public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

    public string AdminNote { get; set; } = string.Empty;

    public string AppraiserNote { get; set; } = string.Empty;

    public ApplicationUser? Appraiser { get; set; }
    public string? AppraiserId { get; set; }

    public ApplicationUser? JobAssigner { get; set; }
    public string? JobAssignerId { get; set; }

    public string? Message { get; set; }

    //Date the client submitted the form
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; }

    //This is the date the form was assigned to an Evaluator
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateAssigned { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    //The date when Evaluator accepted form
    public DateTime DateAccepted { get; set; }


    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateInProcess { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateRejected { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateCompleted { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateReturnToAppraiser { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateSubmittedForApproval { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateCancelled { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateApproved { get; set; }

    public Region? ClientRegion { get; set; }
    public Guid? ClientRegionId { get; set; }

    public Region? PropertyRegion { get; set; }
    public Guid? PropertyRegionId { get; set; }


    public string FrontOfProperyImageURL { get; set; } = string.Empty;
    public string RightSideOfPropertyImageURL { get; set; } = string.Empty;
    public string LeftSideOfPropertImageURL { get; set; } = string.Empty;
    public string BackOfPropertyImageURL { get; set; } = string.Empty;

    public string TypeOfPropertySelectedIds { get; set; } = string.Empty;
    public string ServiceRequestItemSelectId { get; set; } = string.Empty; 
    public string PurposeOfValuationItemSelectedIds { get; set; } = string.Empty;

}
