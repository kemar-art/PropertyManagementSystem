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
        ISnackbar _Snackbar { get; set; }

        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IAuthenticationService _AuthenticationService { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        public NoneLoginResetPassword _noneLoginModel { get; set; } = new NoneLoginResetPassword();

        public string UserId { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            _noneLoginModel = new NoneLoginResetPassword();
            // Extract query parameters
            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userId", out var userId))
            {
                _noneLoginModel.Id = userId;
            }
            else
            {
                _Snackbar.Add("Something went wrong. Please try again later.", Severity.Error);

            }

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("code", out var code))
            {
                _noneLoginModel.ResetToken = code;
            }
            else
            {
                _Snackbar.Add("Something went wrong. Please try again later.", Severity.Error); ;
            }



            IsLoading = false;
        }

        protected async Task OnValidSubmit()
        {
            IsLoading = true;


            NoneLoginResetPassword resetPassword = new()
            {
                Id = _noneLoginModel.Id,
                Email = _noneLoginModel.Email,
                NewPassword = _noneLoginModel.NewPassword,
                ResetToken = _noneLoginModel.ResetToken
            };

            // Make the API call
            var result = await _AuthenticationService.PasswordReset(resetPassword);
            if (result.IsSuccess)
            {
                _Snackbar.Add("Password reset successfully.", Severity.Success);
                _NavigationManager.NavigateTo("/login");
            }
            else
            {
                //Message = result.Message;
                _Snackbar.Add($"{result.Message}", Severity.Error);
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
    }



}
