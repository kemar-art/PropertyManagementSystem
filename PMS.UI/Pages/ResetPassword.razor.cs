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
    public partial class ResetPassword
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAuthenticationService _AuthenticationService { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        public NoneLoginResetPassword _noneLoginResetPassword { get; set; } = new NoneLoginResetPassword();

        public string UserId { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            _noneLoginResetPassword = new NoneLoginResetPassword();
            // Extract query parameters
            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var userId))
            {
                Console.WriteLine($"UserId found: {userId}");
                _noneLoginResetPassword.Id = userId;
            }
            else
            {
                Console.WriteLine("UserId not found in the query parameters.");
            }

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("code", out var code))
            {
                Console.WriteLine($"ResetToken found: {code}");
                _noneLoginResetPassword.ResetToken = code;
            }
            else
            {
                Console.WriteLine("ResetToken not found in the query parameters.");
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


            NoneLoginResetPassword resetPassword = new()
            {
                Id = _noneLoginResetPassword.Id,
                Email = _noneLoginResetPassword.Email,
                NewPassword = _noneLoginResetPassword.NewPassword,
                ResetToken = _noneLoginResetPassword.ResetToken
            };

            // Make the API call
            var result = await _AuthenticationService.PasswordReset(resetPassword);
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
