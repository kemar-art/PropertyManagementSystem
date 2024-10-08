using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Models.Employee;

namespace PMS.UI.Pages.Admin.Employee
{
    public partial class Index
    {
        public string _searchString;
        private bool IsLoading { get; set; } = true;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAdminRepository _AdminRepository { get; set; }

        [Inject]
        public SweetAlertService Swal { get; set; }

        [Inject]
        IJSRuntime jSRuntime { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        public IEnumerable<ApplicationUserVM> _indexModel { get; private set; } = [];

        // Quick filter across columns
        private Func<ApplicationUserVM, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                return true;
            }

            if ($"{x.FirstName} {x.LastName} {x.Email} {x.PhoneNumber}".Contains(_searchString))
            {
                return true;
            }


            return false;
        };

        protected override async Task OnInitializedAsync()
        {
            _indexModel = await _AdminRepository.GetAllEmployees();
            IsLoading = false;
        }

        protected void CreateNewEmployee()
        {
            _NavigationManager.NavigateTo("/create-employee/");
        }

        protected void EditEmployee(string id)
        {
            _NavigationManager.NavigateTo($"/employee/edit/{id}");
        }

        protected void EmployeeDetail(string id)
        {
            _NavigationManager.NavigateTo($"/client/details/{id}");
        }

        protected async Task EmployeeDeletion(string id)
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
                var response = await _AdminRepository.DeleteEmployee(id);
                if (response.IsSuccess)
                {
                    _indexModel = await _AdminRepository.GetAllEmployees();
                    _Snackbar.Add("Record Deleted Successfully.", Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    _Snackbar.Add("Unable to delete the record. Please try again.", Severity.Error);
                }


            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await OnInitializedAsync();
                // Call the JS function to reload the vendor script
                await jSRuntime.InvokeVoidAsync("reloadVendorScript");
            }
        }
    }
}
