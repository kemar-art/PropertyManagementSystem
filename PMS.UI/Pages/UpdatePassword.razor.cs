using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using System.Security.Claims;
using System.Text;

namespace PMS.UI.Pages
{
    public partial class UpdatePassword
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAuthenticationService _AuthenticationService { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        public LoginUserPasswordReset _loginUserPasswordReset { get; set; } = new();

        private string UserId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;
        private bool IsUserAuthenticated { get; set; } = false;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            // Check if the user is authenticated
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            UserId = user.Claims.FirstOrDefault(x => x.Type.Equals("uid")).Value;
            IsUserAuthenticated = user.Identity.IsAuthenticated;
            if (IsUserAuthenticated)
            {

                _loginUserPasswordReset = new LoginUserPasswordReset();
                
            }
            else
            {
                _NavigationManager.NavigateTo("/login");
            }
 
            IsLoading = false;
        }


        private InputType _currentPasswordInput = InputType.Password;

        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            if (_passwordInput == InputType.Password)
            {
                _passwordInput = InputType.Text;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
            }
            else
            {
                _passwordInput = InputType.Password;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
            }
        }

        private InputType _passwordConfirmationInput = InputType.Password;
        private string _passwordConfirmationInputIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordConfirmationVisibility()
        {
            if (_passwordConfirmationInput == InputType.Password)
            {
                _passwordConfirmationInput = InputType.Text;
                _passwordConfirmationInputIcon = Icons.Material.Filled.Visibility;
            }
            else
            {
                _passwordConfirmationInput = InputType.Password;
                _passwordConfirmationInputIcon = Icons.Material.Filled.VisibilityOff;
            }
        }



        protected async Task OnValidSubmit()
        {
            IsLoading = true;


            LoginUserPasswordReset loginUser = new()
            {
                Id = UserId,
                CurrentPassword = _loginUserPasswordReset.CurrentPassword,
                NewPassword = _loginUserPasswordReset.NewPassword,
            };

            // Make the API call
            var result = await _AuthenticationService.UpdateResetPassword(loginUser);
            if (result.Exists)
            {
                Message = "Password reset successfully.";
                _NavigationManager.NavigateTo("/profile");
            }
            else
            {
                Message = result.Message;
            }

            IsLoading = false;
        }
    }


}
