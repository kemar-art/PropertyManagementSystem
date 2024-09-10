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
            // Reset validation messages and show validation errors
            _showValidation = true;
            _validationMessageStore.Clear();

            // Track form validity
            var isValid = true;

            // Validate RegionId (Client and Property)
            var clientRegionField = new FieldIdentifier(_editModel, nameof(_editModel.ClientRegionId));
            if (_editModel.ClientRegionId == Guid.Empty)
            {
                isValid = false;
                _validationMessageStore.Add(clientRegionField, "Please select a parish.");
            }

            var propertyRegionField = new FieldIdentifier(_editModel, nameof(_editModel.PropertyRegionId));
            if (_editModel.PropertyRegionId == Guid.Empty)
            {
                isValid = false;
                _validationMessageStore.Add(propertyRegionField, "Please select a parish.");
            }

            // Validate checkboxes (Type of Property and Purpose of Evaluation)
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

            // Validate required text fields
            var fieldsToValidate = new List<string>
    {
                nameof(_editModel.FirstName),
                nameof(_editModel.LastName),
                nameof(_editModel.PhoneNumber),
                nameof(_editModel.Email),
                nameof(_editModel.Address),
                nameof(_editModel.Volume),
                nameof(_editModel.Folio),
                nameof(_editModel.PropertyAddress),
                nameof(_editModel.StrataPlan),
                nameof(_editModel.MortgageInstitution),
                nameof(_editModel.SecondaryContactPhoneNumber)
            };

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

            // If valid, submit the form
            if (isValid)
            {
                try
                {
                    _editModel.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(x => x.IsChecked).Select(x => x.Id));
                    _editModel.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(x => x.IsChecked).Select(x => x.Id));

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
            else
            {
                EditContext.NotifyValidationStateChanged(); // Update UI with validation errors
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


        protected void BackToIndex()
        {
            _NavigationManager.NavigateTo("/submitted-forms/");
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