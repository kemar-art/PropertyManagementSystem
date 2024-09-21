using Application.Contracts.Repository_Interface;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Employee;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Forms
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        public IFormRepository _FormRepository { get; set; }

        [Inject]
        public SweetAlertService Swal { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        IJSRuntime jSRuntime { get; set; }

        [Inject]
        ICheckBoxRepository _CheckBoxRepository { get; set; }

        public IEnumerable<FormVM> _indexModel { get; private set; } = [];

        public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = [];

        public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = [];

        public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = [];

        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        public string _searchString;

        // Quick filter across columns
        private Func<FormVM, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                return true;
            }

            if ($"{x.CustomerId} {x.FirstName} {x.LastName} {x.Email} {x.PropertyAddress}".Contains(_searchString))
            {
                return true;
            }

            return false;
        };

        protected void EditForm(Guid id)
        {
            _NavigationManager.NavigateTo($"/edit/{id}");
        }

        protected void FormDetails(Guid id)
        {
            _NavigationManager.NavigateTo($"/details/{id}");
        }

        protected async Task DeleteForm(Guid id)
        {
            var result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "You won't be able to revert this!",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonColor = "#d33",
                CancelButtonColor = "#008000",
                ConfirmButtonText = "Yes, delete it!"
            });
            if (result.IsConfirmed)
            {
                var response = await _FormRepository.DeleteForm(id);
                if (response.Success)
                {
                    // Refresh the data after deletion
                    _indexModel = await _FormRepository.GetAllForms();
                    _Snackbar.Add("Record Deleted Successfully.", Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    _Snackbar.Add("Unable to delete the record. Please try again.", Severity.Error);
                }
            }
        }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
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

                // Retrieve forms and map checkbox titles
                _indexModel = await _FormRepository.GetAllForms();

                foreach (var checkedItem in _indexModel)
                {
                    checkedItem.TypeOfPropertySelectedIds = string.Join(", ", TypeOfPropertyCheckBoxItemVM
                        .Where(c => checkedItem.TypeOfPropertySelectedIds.Split(',').Contains(c.Id.ToString()))
                        .Select(c => c.Title));

                    checkedItem.PurposeOfValuationItemSelectedIds = string.Join(", ", PurposeOfEvaluationCheckBoxesVM
                        .Where(c => checkedItem.PurposeOfValuationItemSelectedIds.Split(',').Contains(c.Id.ToString()))
                        .Select(c => c.Title));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Call the JS function to reload the vendor script
                await jSRuntime.InvokeVoidAsync("reloadVendorScript");

            }

        }

    }
}
