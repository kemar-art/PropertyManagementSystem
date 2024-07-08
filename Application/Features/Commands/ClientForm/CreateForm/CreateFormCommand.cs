using Domain.CheckBox;
using Domain.CheckBox.PurposeValuation;
using Domain.CheckBox.ServiceRequest;
using Domain.CheckBox.TypeOfProperty;
using MediatR;

namespace Application.Features.Commands.ClientForm.CreateForm;

public class CreateFormCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string InstructionsIssuedBy { get; set; } = string.Empty;

    public string PropertyAddress { get; set; } = string.Empty;

    public string PropertyDirection { get; set; } = string.Empty;

    public int Volume { get; set; }

    public int Folio { get; set; }

    public string StrataPlan { get; set; } = string.Empty;

    public bool IsKeyAvailable { get; set; }

    public string MortgageInstitution { get; set; } = string.Empty;

    public string Other { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string SecondaryContactFirstName { get; set; } = string.Empty;

    public string SecondaryContactLastName { get; set; } = string.Empty;

    public string SecondaryContactEmail { get; set; } = string.Empty;

    public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

    //public List<PurposeOfValuationCheckBox>? PurposeOfValuationCheckBoxItems { get; set; } = [];

    //public List<ServiceRequestCheckBox>? ServiceRequestCheckBoxItems { get; set; } = [];

    //public List<TypeOfPropertyCheckBox>? TypeOfPropertyCheckBoxItems { get; set; } = [];



    //public List<CheckBoxIPropertyDTO> TypeOfPropertyCheckBoxItem { get; set; } = [];

    //public List<CheckBoxIPropertyDTO> ServiceRequestCheckBoxes { get; set; } = [];

    //public List<CheckBoxIPropertyDTO> PurposeOfEvaluationCheckBoxes { get; set; } = [];

    //public List<CheckBoxIPropertyDTO> SelectedServiceRequestCheckBoxes { get; set; } = [];

    //public List<CheckBoxIPropertyDTO> SelectedTypeOfPropertyCheckBoxes { get; set; } = [];

    //public List<CheckBoxIPropertyDTO> SelectedPurposeOfEvaluationCheckBoxes { get; set; } = [];
}