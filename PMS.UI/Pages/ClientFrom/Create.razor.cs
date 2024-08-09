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

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Create
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ICheckBoxRepository _CheckBoxRepository { get; set; }

        private bool IsLoading { get; set; } = true;
        private int currentStep = 1;

        public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = new();
        public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = new();
        public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = new();
        public FormVM FormVM { get; set; } = new();
        IEnumerable<Region> Regions { get; set; }


        private ValidationMessageStore _validationMessageStore;
        private EditContext EditContext;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            try
            {
                var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
                ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = vm.IsChecked
                }).ToList();

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

                Regions = await _RegionRepositoey.GetAllRegion() ?? new List<Region>();

                // Initialize EditContext
                EditContext = new EditContext(FormVM);
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

        private bool ValidateServiceRequestCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return ServiceRequestCheckBoxesVM.Any(c => c.IsChecked);
        }
        private void SetServiceRequestValidationMessage(string message)
        {
            FormVM.ServiceRequestValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(FormVM, nameof(FormVM.ServiceRequestValidationMessage)));
        }

        private bool ValidateTypeOfPropertyCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return TypeOfPropertyCheckBoxItemVM.Any(c => c.IsChecked);
        }
        private void TypeOfPropertyValidationMessage(string message)
        {
            FormVM.TypeOfPropertyValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(FormVM, nameof(FormVM.TypeOfPropertyValidationMessage)));
        }


        private bool ValidatePurposeOfEvaluationCheckBoxes()
        {
            // Check if at least one checkbox is checked
            return PurposeOfEvaluationCheckBoxesVM.Any(c => c.IsChecked);
        }
        private void PurposeOfEvaluationValidationMessage(string message)
        {
            FormVM.PurposeOfEvaluationValidationMessage = message;
            EditContext.NotifyFieldChanged(new FieldIdentifier(FormVM, nameof(FormVM.PurposeOfEvaluationValidationMessage)));
        }



        private bool _showValidation = false;

        private async Task NextStep()
        {
            // Show validation errors
            _showValidation = true;

            // Clear previous validation messages
            FormVM.ServiceRequestValidationMessage = string.Empty;
            FormVM.TypeOfPropertyValidationMessage = string.Empty;
            FormVM.PurposeOfEvaluationValidationMessage = string.Empty;
            _validationMessageStore.Clear();

            // Track if the form is valid
            var isValid = true;

            // Determine the fields to validate based on the current step
            var fieldsToValidate = new List<string>();

            if (currentStep == 1)
            {
                fieldsToValidate.Add(nameof(FormVM.FirstName));
                fieldsToValidate.Add(nameof(FormVM.LastName));
                fieldsToValidate.Add(nameof(FormVM.PhoneNumber));
                fieldsToValidate.Add(nameof(FormVM.Email));
                fieldsToValidate.Add(nameof(FormVM.Address));
            }
            else if (currentStep == 2)
            {
                fieldsToValidate.Add(nameof(FormVM.Volume));
                fieldsToValidate.Add(nameof(FormVM.Folio));
                fieldsToValidate.Add(nameof(FormVM.IsKeyAvailable));
                fieldsToValidate.Add(nameof(FormVM.RegionId)); // Add RegionId to the fields to validate
                fieldsToValidate.Add(nameof(FormVM.PropertyAddress));
                fieldsToValidate.Add(nameof(FormVM.StrataPlan));
                fieldsToValidate.Add(nameof(FormVM.MortgageInstitution));

                // Validate RegionId
                var regionField = new FieldIdentifier(FormVM, nameof(FormVM.RegionId));
                _validationMessageStore.Clear(regionField); // Clear previous validation messages for RegionId

                if (FormVM.RegionId == Guid.Empty)
                {
                    isValid = false;
                    _validationMessageStore.Add(regionField, "Please select a parish.");
                    EditContext.NotifyValidationStateChanged(); // Notify the EditContext of validation state change
                }

                // Validate the checkboxes for service requests
                if (!ValidateServiceRequestCheckBoxes())
                {
                    isValid = false;
                    SetServiceRequestValidationMessage("At least one service request must be selected.");
                }

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
                fieldsToValidate.Add(nameof(FormVM.SecondaryContactFirstName));
                fieldsToValidate.Add(nameof(FormVM.SecondaryContactLastName));
                fieldsToValidate.Add(nameof(FormVM.SecondaryContactPhoneNumber));
            }

            // Validate each field
            foreach (var field in fieldsToValidate)
            {
                var fieldIdentifier = new FieldIdentifier(FormVM, field);
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

        private async Task HandleValidSubmit()
        {
            // Populate the selected IDs as comma-separated strings
            FormVM.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(c => c.IsChecked).Select(c => c.Id));
            FormVM.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));
            FormVM.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));

            try
            {
                var response = await _FormRepository.CreateForm(FormVM);

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

        private Task HandleInvalidSubmit()
        {
            // Handle invalid form submission
            Console.WriteLine("Form is invalid");
            return Task.CompletedTask;
        }
    }


}