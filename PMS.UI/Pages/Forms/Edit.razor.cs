using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Forms
{
    public partial class Edit
    {
        private bool IsLoading { get; set; } = true;
        private int currentStep = 1;
        private bool _showValidation = false;

        private ValidationMessageStore _validationMessageStore;
        private EditContext EditContext;


        [Parameter]
        public Guid FormId { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ICheckBoxRepository _CheckBoxRepository { get; set; }

        public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = [];

        public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = [];

        public FormVM _editModel { get; set; } = new();
        IEnumerable<Region> Regions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                // Fetch all Purpose of Evaluation checkboxes
                var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
                // Fetch all Type of Property checkboxes
                var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();

                // Get form details, including previously checked items (if any)
                _editModel = await _FormRepository.GetASingleFormDetails(FormId);

                // Set up checkboxes for Purpose of Valuation
                PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = _editModel.PurposeOfValuationItemSelectedIds?.Split(',').Contains(vm.Id.ToString()) ?? false // Check based on selected IDs
                }).ToList();

                // Set up checkboxes for Type of Property
                TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = _editModel.TypeOfPropertySelectedIds?.Split(',').Contains(vm.Id.ToString()) ?? false // Check based on selected IDs
                }).ToList();

                // Load regions (if required)
                Regions = await _RegionRepositoey.GetAllRegion() ?? [];

                // Initialize EditContext
                EditContext = new EditContext(_editModel);
                _validationMessageStore = new ValidationMessageStore(EditContext);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message)
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }


        private async Task OnValidSubmit()
        {
            _editModel.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(x => x.IsChecked).Select(x => x.Id));
            //_editModel.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(x => x.IsChecked).Select(x => x.Id));
            _editModel.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(x => x.IsChecked).Select(x => x.Id));

            try
            {
                var response = await _FormRepository.UpdateForm(_editModel);

                if (response.Success)
                {
                    _Snackbar.Add("Record updated successfully.", Severity.Success);
                    _NavigationManager.NavigateTo("/submitted-forms");
                }
                else
                {
                    // Handle error
                    Console.WriteLine("Error: " + response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }

        private bool ValidateTypeOfPropertyCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return TypeOfPropertyCheckBoxItemVM.Any(c => c.IsChecked);
        }
        private void TypeOfPropertyValidationMessage(string message)
        {
            _editModel.TypeOfPropertyValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(_editModel, nameof(_editModel.TypeOfPropertyValidationMessage)));
        }

        private bool ValidatePurposeOfEvaluationCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return PurposeOfEvaluationCheckBoxesVM.Any(c => c.IsChecked);
        }
        private void PurposeOfEvaluationValidationMessage(string message)
        {
            _editModel.PurposeOfEvaluationValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(_editModel, nameof(_editModel.PurposeOfEvaluationValidationMessage)));
        }

        private async Task NextStep()
        {
            // Show validation errors
            _showValidation = true;

            // Clear previous validation messages
            //_editModel.ServiceRequestValidationMessage = string.Empty;
            _editModel.TypeOfPropertyValidationMessage = string.Empty;
            _editModel.PurposeOfEvaluationValidationMessage = string.Empty;
            _validationMessageStore.Clear();

            // Track if the form is valid
            var isValid = true;

            // Determine the fields to validate based on the current step
            var fieldsToValidate = new List<string>();

            if (currentStep == 1)
            {
                fieldsToValidate.Add(nameof(_editModel.FirstName));
                fieldsToValidate.Add(nameof(_editModel.LastName));
                fieldsToValidate.Add(nameof(_editModel.PhoneNumber));
                fieldsToValidate.Add(nameof(_editModel.Email));
                fieldsToValidate.Add(nameof(_editModel.Address));

                // Validate RegionId
                var regionField = new FieldIdentifier(_editModel, nameof(_editModel.ClientRegionId));
                _validationMessageStore.Clear(regionField); // Clear previous validation messages for RegionId

                if (_editModel.ClientRegionId == Guid.Empty)
                {
                    isValid = false;
                    _validationMessageStore.Add(regionField, "Please select a parish.");
                    EditContext.NotifyValidationStateChanged(); // Notify the EditContext of validation state change
                }
            }
            else if (currentStep == 2)
            {
                fieldsToValidate.Add(nameof(_editModel.Volume));
                fieldsToValidate.Add(nameof(_editModel.Folio));
                fieldsToValidate.Add(nameof(_editModel.IsKeyAvailable));
                fieldsToValidate.Add(nameof(_editModel.PropertyAddress));
                fieldsToValidate.Add(nameof(_editModel.StrataPlan));
                fieldsToValidate.Add(nameof(_editModel.MortgageInstitution));

                // Validate RegionId
                var regionField = new FieldIdentifier(_editModel, nameof(_editModel.PropertyRegionId));
                _validationMessageStore.Clear(regionField); // Clear previous validation messages for RegionId

                if (_editModel.PropertyRegionId == Guid.Empty)
                {
                    isValid = false;
                    _validationMessageStore.Add(regionField, "Please select a parish.");
                    EditContext.NotifyValidationStateChanged(); // Notify the EditContext of validation state change
                }

                // Validate the checkboxes for service requests
                //if (!ValidateServiceRequestCheckBoxes())
                //{
                //    isValid = false;
                //    SetServiceRequestValidationMessage("At least one service request must be selected.");
                //}

                if (!ValidateTypeOfPropertyCheckBoxes())
                {
                    isValid = false;
                    TypeOfPropertyValidationMessage("At least one type of property must be selected.");
                }

                if (!ValidatePurposeOfEvaluationCheckBoxes())
                {
                    isValid = false;
                    PurposeOfEvaluationValidationMessage("At least one purpose of evaluation must be selected.");
                }
            }
            else if (currentStep == 3)
            {
                //fieldsToValidate.Add(nameof(_editModel.SecondaryContactFirstName));
                //fieldsToValidate.Add(nameof(_editModel.SecondaryContactLastName));
                fieldsToValidate.Add(nameof(_editModel.SecondaryContactPhoneNumber));
            }

            // Validate each field
            foreach (var field in fieldsToValidate)
            {
                var fieldIdentifier = new FieldIdentifier(_editModel, field);
                EditContext.NotifyFieldChanged(fieldIdentifier); // Notify that a field has changed
                var validationMessages = EditContext.GetValidationMessages(fieldIdentifier);

                // If any field has validation messages, mark the form as invalid
                if (validationMessages.Any())
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                // Proceed to the next step only if validation passes
                if (currentStep < 3)
                {
                    currentStep++;
                    _showValidation = false; // Reset validation flag after moving to the next step
                }
            }
            else
            {
                // Handle validation failure
                Console.WriteLine("Validation failed, staying on the current step.");
            }
        }

        private void PreviousStep()
        {
            if (currentStep > 1)
            {
                currentStep--;
            }
        }

        //private void ConvertToUpperCase(string fieldName)
        //{
        //    // Get the property info for the field
        //    var property = typeof(FormVM).GetProperty(fieldName);
        //    if (property != null && property.CanRead)
        //    {
        //        // Get the current value, convert to upper case, and set it back
        //        var currentValue = property.GetValue(_editModel)?.ToString() ?? string.Empty;
        //        var upperCaseValue = currentValue.ToUpper();

        //        // Update the property with the upper case value
        //        property.SetValue(_editModel, upperCaseValue);

        //        // Notify that the field has changed
        //        EditContext.NotifyFieldChanged(new FieldIdentifier(_editModel, fieldName));

        //        // Trigger UI update
        //        InvokeAsync(StateHasChanged);
        //    }
        //}

        private void ConvertToUpperCase(string fieldName)
        {
            var propertyInfo = _editModel.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(_editModel)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    propertyInfo.SetValue(_editModel, value.ToUpper());
                }
            }
        }

    }
}