using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Models.Auth;

namespace PMS.UI.Pages
{
    public partial class ExternalPasswordRest
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        public ExternalPasswordResetVM _externalPasswordReset { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var userId))
            {
                UserId = userId;
            }
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("code", out var code))
            {
                Code = code;
            }
        }

        private bool IsLoading { get; set; } = true;

        public string Message { get; set; } = string.Empty;

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
            //IsLoading = true;

            //var sendEmailToResetPassword = await _AuthenticationService.ExternalPasswordReset(_externalPasswordReset);
            //if (sendEmailToResetPassword.Exists)
            //{
            //    // Navigate to the home page or any other page
            //    Message = sendEmailToResetPassword.Message;
            //    _NavigationManager.NavigateTo("/password-reset");
            //}
            //else
            //{
            //    Message = sendEmailToResetPassword.Message;
            //    _NavigationManager.NavigateTo("/password-reset");
            //}

            //IsLoading = false;
        }
    }
}