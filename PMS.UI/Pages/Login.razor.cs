using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;

namespace PMS.UI.Pages
{
    public partial class Login
    {
        public LoginVM  LoginVM { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            LoginVM = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.IsAuthenticated(LoginVM))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }
    }
}