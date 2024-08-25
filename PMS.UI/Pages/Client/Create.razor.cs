using Application.Contracts.Repository_Interface;
using Blazorise.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;
using System;
using System.Reflection;
using System.Security.AccessControl;

namespace PMS.UI.Pages.Client
{
    public partial class Create
    {
        private bool IsLoading { get; set; } = true;
        private int currentStep = 1;
        private bool _showValidation = false;

        private ValidationMessageStore _validationMessageStore;
        private EditContext EditContext;

        public FormVM _createModel { get; set; } = new();

        public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = [];

        public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = [];

        public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = [];
        
        IEnumerable<Region> Regions { get; set; } = [];
        
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ICheckBoxRepository _CheckBoxRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            try
            {
                //var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
                //ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
                //{
                //    Id = vm.Id,
                //    Title = vm.Title,
                //    IsChecked = vm.IsChecked
                //}).ToList();

                var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
                PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = vm.IsChecked
                }).ToList();

                var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
                TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = vm.IsChecked
                }).ToList();

                Regions = await _RegionRepositoey.GetAllRegion() ?? [];

                // Initialize EditContext
                EditContext = new EditContext(_createModel);
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
            // Populate the selected IDs as comma-separated strings
            _createModel.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(c => c.IsChecked).Select(c => c.Id));
            //_createModel.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));
            _createModel.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));

            try
            {
                var response = await _FormRepository.CreateForm(_createModel);

                if (response.Success)
                {
                    _NavigationManager.NavigateTo($"/success/{response.Data}");
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

        //private bool ValidateServiceRequestCheckBoxes()
        //{
        //    // Check if at least one checkbox is checked
        //    return ServiceRequestCheckBoxesVM.Any(c => c.IsChecked);
        //}
        //private void SetServiceRequestValidationMessage(string message)
        //{
        //    _createModel.ServiceRequestValidationMessage = message;
        //    EditContext.NotifyFieldChanged(new FieldIdentifier(_createModel, nameof(_createModel.ServiceRequestValidationMessage)));
        //}

        private bool ValidateTypeOfPropertyCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return TypeOfPropertyCheckBoxItemVM.Any(c => c.IsChecked);
        }
        private void TypeOfPropertyValidationMessage(string message)
        {
            _createModel.TypeOfPropertyValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(_createModel, nameof(_createModel.TypeOfPropertyValidationMessage)));
        }

        private bool ValidatePurposeOfEvaluationCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return PurposeOfEvaluationCheckBoxesVM.Any(c => c.IsChecked);
        }
        private void PurposeOfEvaluationValidationMessage(string message)
        {
            _createModel.PurposeOfEvaluationValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(_createModel, nameof(_createModel.PurposeOfEvaluationValidationMessage)));
        }

        private async Task NextStep()
        {
            // Show validation errors
            _showValidation = true;

            // Clear previous validation messages
            _createModel.ServiceRequestValidationMessage = string.Empty;
            _createModel.TypeOfPropertyValidationMessage = string.Empty;
            _createModel.PurposeOfEvaluationValidationMessage = string.Empty;
            _validationMessageStore.Clear();

            // Track if the form is valid
            var isValid = true;

            // Determine the fields to validate based on the current step
            var fieldsToValidate = new List<string>();

            if (currentStep == 1)
            {
                fieldsToValidate.Add(nameof(_createModel.FirstName));
                fieldsToValidate.Add(nameof(_createModel.LastName));
                fieldsToValidate.Add(nameof(_createModel.PhoneNumber));
                fieldsToValidate.Add(nameof(_createModel.Email));
                fieldsToValidate.Add(nameof(_createModel.Address));

                // Validate RegionId
                var regionField = new FieldIdentifier(_createModel, nameof(_createModel.ClientRegionId));
                _validationMessageStore.Clear(regionField); // Clear previous validation messages for RegionId

                if (_createModel.ClientRegionId == Guid.Empty)
                {
                    isValid = false;
                    _validationMessageStore.Add(regionField, "Please select a parish.");
                    EditContext.NotifyValidationStateChanged(); // Notify the EditContext of validation state change
                }
            }
            else if (currentStep == 2)
            {
                fieldsToValidate.Add(nameof(_createModel.Volume));
                fieldsToValidate.Add(nameof(_createModel.Folio));
                fieldsToValidate.Add(nameof(_createModel.IsKeyAvailable));
                fieldsToValidate.Add(nameof(_createModel.PropertyAddress));
                fieldsToValidate.Add(nameof(_createModel.StrataPlan));
                fieldsToValidate.Add(nameof(_createModel.MortgageInstitution));

                // Validate RegionId
                var regionField = new FieldIdentifier(_createModel, nameof(_createModel.PropertyRegionId));
                _validationMessageStore.Clear(regionField); // Clear previous validation messages for RegionId

                if (_createModel.PropertyRegionId == Guid.Empty)
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
                fieldsToValidate.Add(nameof(_createModel.SecondaryContactFirstName));
                fieldsToValidate.Add(nameof(_createModel.SecondaryContactLastName));
                fieldsToValidate.Add(nameof(_createModel.SecondaryContactPhoneNumber));
            }

            // Validate each field
            foreach (var field in fieldsToValidate)
            {
                var fieldIdentifier = new FieldIdentifier(_createModel, field);
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
    }


}