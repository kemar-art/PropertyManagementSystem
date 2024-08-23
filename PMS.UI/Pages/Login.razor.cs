using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using System.Threading.Tasks;

namespace PMS.UI.Pages
{
    public partial class Login
    {
        public LoginVM _loginModel { get; set; }
        public string Message { get; set; }
        private bool IsLoading { get; set; } = true;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        private ILocalStorageService _localStorage { get; set; }

        [Inject]
        private ISessionStorageService _sessionStorage { get; set; }

        [Inject]
        private IAuthenticationService _AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            IsLoading = true;
            _loginModel = new LoginVM();
            IsLoading = false;
        }

        protected async Task HandleLogin()
        {
            IsLoading = true;

            var isAuthenticated = await _AuthenticationService.IsAuthenticated(_loginModel);
            if (isAuthenticated)
            {
                // Navigate to the home page or any other page
                NavigationManager.NavigateTo("/");
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
