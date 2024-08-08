using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;
using System;

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

        private bool _showValidation = false;

        private async Task NextStep()
        {
            _showValidation = true; // Show validation errors

            // Define a list of field identifiers for the current step
            var fieldsToValidate = new List<FieldIdentifier>();

            if (currentStep == 1)
            {
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.FirstName)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.LastName)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.PhoneNumber)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.Email)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.Address)));
            }
            else if (currentStep == 2)
            {
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.Volume)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.Folio)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.IsKeyAvailable)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.RegionId)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.PropertyAddress)));
            }
            else if (currentStep == 3)
            {
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.SecondaryContactFirstName)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.SecondaryContactLastName)));
                fieldsToValidate.Add(new FieldIdentifier(FormVM, nameof(FormVM.SecondaryContactPhoneNumber)));
            }

            // Trigger the validation
            EditContext.Validate();

            // Check if all fields in the current step are valid
            var isValid = true;
            foreach (var field in fieldsToValidate)
            {
                if (EditContext.GetValidationMessages(field).Any())
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                // Proceed to the next step only if validation passes
                if (currentStep < 3)
                {
                    currentStep++;
                    _showValidation = false;
                    isValid = false;
                    // Reset validation flag after moving to the next step
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





    //public partial class Create
    //{
    //    [Inject]
    //    NavigationManager _NavigationManager { get; set; }

    //    [Inject]
    //    IFormRepository _FormRepository { get; set; }

    //    [Inject]
    //    IRegionRepositoey _RegionRepositoey { get; set; }

    //    [Inject]
    //    ICheckBoxRepository _CheckBoxRepository { get; set; }

    //    private bool IsLoading { get; set; } = true;

    //    public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = new();

    //    public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = new();

    //    public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = new();

    //    public FormVM FormVM { get; set; } = new();

    //    IEnumerable<Region> Regions { get; set; } = new List<Region>();

    //    protected override async Task OnInitializedAsync()
    //    {
    //        IsLoading = true;

    //        try
    //        {
    //            var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
    //            ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
    //            PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
    //            TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            Regions = await _RegionRepositoey.GetAllRegion() ?? new List<Region>();
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle the exception (e.g., log it, show an error message)
    //            Console.WriteLine($"Error loading data: {ex.Message}");
    //        }
    //        finally
    //        {
    //            IsLoading = false;
    //        }
    //    }

    //    private async Task OnValidSubmit()
    //    {
    //        // Populate the selected IDs as comma-separated strings
    //        FormVM.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(c => c.IsChecked).Select(c => c.Id));
    //        FormVM.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));
    //        FormVM.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));

    //        try
    //        {
    //            var response = await _FormRepository.CreateForm(FormVM);

    //            if (response.Success)
    //            {
    //                _NavigationManager.NavigateTo($"/success/{response.Data}");
    //            }
    //            else
    //            {
    //                // Handle error
    //                Console.WriteLine("Error: " + response.ErrorMessage);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle unexpected errors
    //            Console.WriteLine("Unexpected error: " + ex.Message);
    //        }
    //    }
    //}

}