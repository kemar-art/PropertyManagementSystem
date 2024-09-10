using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Models.Employee;

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
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAdminRepository _AdminRepository { get; set; }

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
            _indexModel = await _AdminRepository.GetAllClients();
            IsLoading = false;
        }

        protected void CreateNewEmployee()
        {
            _NavigationManager.NavigateTo("/create-employee/");
        }

        protected void EditForm(Guid id)
        {
            _NavigationManager.NavigateTo($"/edit/profile/{id}");
        }
        
        protected void EmployeeDetail(Guid id)
        {
            _NavigationManager.NavigateTo($"/edit/client/details/{id}");
        }

        protected async Task EmployeeDeletion(Guid id)
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
                var response = await _AdminRepository.DeleteEmployee(id.ToString());
                if (response.Success)
                {
                    // Refresh the data after deletion
                    _indexModel = await _AdminRepository.GetAllClients();
                    StateHasChanged();
                }
                else
                {
                    Message = response.Message;
                }
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
