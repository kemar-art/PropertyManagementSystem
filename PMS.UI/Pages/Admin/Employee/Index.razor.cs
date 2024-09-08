using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Models.Employee;

namespace PMS.UI.Pages.Admin.Employee
{
    public partial class Index
    {
        public string _searchString;

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
            _indexModel = await _AdminRepository.GetAllEmployees();
            IsLoading = false;
        }

        protected void CreateNewEmployee()
        {
            _NavigationManager.NavigateTo("/create-employee/");
        }

        private bool IsLoading { get; set; } = true;
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
