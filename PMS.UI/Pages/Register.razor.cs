using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;

namespace PMS.UI.Pages
{
    public partial class Register
    {
        public RegisterVM RegisterVM { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            RegisterVM = new RegisterVM();
        }

        protected async Task HandleRegister()
        {
            var result = await AuthenticationService.IsRegister(RegisterVM.FirstName, RegisterVM.LastName, RegisterVM.Email, RegisterVM.Gender, RegisterVM.DateOfBirth, RegisterVM.Password);

            if (result)
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Something went wrong, please try again.";
        }
    }
}