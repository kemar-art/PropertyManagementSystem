using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Admin.Clients
{
    public partial class Index
    {
        public string _searchString;
        private bool IsLoading { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        [Inject]
        public SweetAlertService Swal { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        IJSRuntime jSRuntime { get; set; }

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAdminRepository _AdminRepository { get; set; }

        public IEnumerable<ClientVM> _indexModel { get; private set; } = [];

        // Quick filter across columns
        private Func<ClientVM, bool> _quickFilter => x =>
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
            _indexModel = await _AdminRepository.GetAllClients();
            IsLoading = false;
        }

        protected void EditForm(string id)
        {
            _NavigationManager.NavigateTo($"/edit/profile/{id}");
        }

        protected void ClientDetail(string id)
        {
            _NavigationManager.NavigateTo($"/edit/client/details/{id}");
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
                    _indexModel = await _AdminRepository.GetAllClients();
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
                // Call the JS function to reload the vendor script
                await jSRuntime.InvokeVoidAsync("reloadVendorScript");
            }
        }
    }


}


//protected void EditEmployee(string userId)
//{
//    _NavigationManager.NavigateTo($"/employee/edit/{userId}");
//}

//protected void EmployeeDetails(string userId)
//{
//    _NavigationManager.NavigateTo($"/employee/details/{userId}");
//}

//protected async Task DeleteEmployee(string userId)
//{
//    var response = await _AdminRepository.DeleteEmployee(userId);
//    if (response.Success)
//    {
//        Refresh the data after deletion
//       _indexModel = await _AdminRepository.GetAllEmployees();
//        StateHasChanged();
//    }
//    else
//    {
//        Message = response.Message;
//    }
//}
