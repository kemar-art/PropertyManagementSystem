using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using System.Text;

namespace PMS.UI.Pages
{
    public partial class ResetPassword
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAuthenticationService _AuthenticationService { get; set; }

        public PasswordReset _passwordReset { get; set; } = new PasswordReset();

        public string UserId { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        protected override void OnInitialized()
        {
            IsLoading = true;
            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var userId))
            {
                UserId = userId;
            }
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("code", out var code))
            {
                _passwordReset.ResetToken = code;
            }

            IsLoading = false;
        }

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

            PasswordReset passwordReset = new()
            {
                Email = _passwordReset.Email,
                Password = _passwordReset.Password,
                ResetToken = _passwordReset.ResetToken,
            };

            // Prepare the request to reset the password
            var result = await _AuthenticationService.ResetPassword(passwordReset);
            if (result.Exists)
            {
                Message = "Password reset successfully.";
                _NavigationManager.NavigateTo("/login");
            }
            else
            {
                Message = result.Message;
            }

            IsLoading = false;
        }
    }
}