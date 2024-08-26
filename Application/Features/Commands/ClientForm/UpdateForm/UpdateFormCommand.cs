using Domain;
using Domain.Common;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.Commands.ClientForm.UpdateForm;

public class UpdateFormCommand : IRequest<BaseResult<Unit>>
{
    public Guid Id { get; set; }

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

    public string SecondaryContactName { get; set; } = string.Empty;

    public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

    [ForeignKey("ClientRegionId")]
    public Region? ClientRegion { get; set; }
    public Guid? ClientRegionId { get; set; }

    [ForeignKey("PropertyRegionId")]
    public Region? PropertyRegion { get; set; }
    public Guid? PropertyRegionId { get; set; }

    public string TypeOfPropertySelectedIds { get; set; } = string.Empty;
    public string ServiceRequestItemSelectId { get; set; } = string.Empty;
    public string PurposeOfValuationItemSelectedIds { get; set; } = string.Empty;
}
