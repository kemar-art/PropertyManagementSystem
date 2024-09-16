using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using System.Threading.Tasks;

namespace PMS.UI.Pages.Admin.Authentication
{
    public partial class AdminLogin
    {
        public LoginVM _loginModel { get; set; }
        public string Message { get; set; } = string.Empty;
        private bool IsLoading { get; set; } = true;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        private IAuthenticationService _AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            IsLoading = true;
            _loginModel = new LoginVM();
            IsLoading = false;
        }

        protected async Task OnValidSubmit()
        {

            IsLoading = true;
            var isAuthenticated = await _AuthenticationService.IsAuthenticated(_loginModel);
            if (isAuthenticated.IsAuthenticate)
            {

                if (isAuthenticated.Role == "Client")
                {
                    // Navigate to the home page or any other page
                    await _AuthenticationService.Logout();
                    _Snackbar.Add("Not authorized to access admin portal.", Severity.Warning);
                    _NavigationManager.NavigateTo("/login");
                }
                else
                {
                    _NavigationManager.NavigateTo("/admin/dashboard/");
                }

            }
            else
            {
                _Snackbar.Add("Invalid username or password", Severity.Error);
            }

            IsLoading = false;
        }

        private bool _passwordVisibility;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            if (_passwordVisibility)
            {
                _passwordVisibility = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _passwordVisibility = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }


    }
}
