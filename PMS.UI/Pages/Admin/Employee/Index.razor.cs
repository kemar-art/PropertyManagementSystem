using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Models.Employee;

namespace PMS.UI.Pages.Admin.Employee
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAdminRepository _AdminRepository { get; set; }

        public IEnumerable<ApplicationUserVM> _indexModel { get; private set; } = [];

        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        protected void EditEmployee(string userId)
        {
            _NavigationManager.NavigateTo($"/employee/edit/{userId}");
        }

        protected void EmployeeDetails(string userId)
        {
            _NavigationManager.NavigateTo($"/employee/details/{userId}");
        }

        protected async Task DeleteEmployee(string userId)
        {
            var response = await _AdminRepository.DeleteEmployee(userId);
            if (response.Success)
            {
                // Refresh the data after deletion
                _indexModel = await _AdminRepository.GetAllEmployees();
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _indexModel = await _AdminRepository.GetAllEmployees();
            IsLoading = false;
        }
    }
}