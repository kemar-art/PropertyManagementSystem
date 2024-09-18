using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using PMS.UI.Services.Base;
using System.Threading.Tasks;

namespace PMS.UI.Pages.Admin.Authentication
{
    public partial class AdminForgotPassword
    {
        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        public ForgetPassword _forgetPasswordModel { get; set; }

        [Inject]
        public IAuthenticationService _AuthenticationService { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        NavigationManager _NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            IsLoading = true;
            _forgetPasswordModel = new ForgetPassword();
            IsLoading = false;
        }


        protected async Task OnValidSubmit()
        {
            IsLoading = true;

            try
            {
                // Attempt to call the API and expect a CustomResponse on success
                var sendEmailToResetPassword = await _AuthenticationService.AdminForgetPassword(_forgetPasswordModel);

                // Handle success response (CustomResponse)
                if (sendEmailToResetPassword.IsSuccess)
                {
                    //_Snackbar.Add(sendEmailToResetPassword.Message, Severity.Success);
                    Message = sendEmailToResetPassword.Message;
                    _NavigationManager.NavigateTo("/admin/forget-password/");
                }
            }
            catch (ApiException<ProblemDetails> ex) // Catch specific API exceptions (e.g., 404, 400)
            {
                // Handle the exception based on the status code and response message
                if (ex.StatusCode == 404)
                {
                    _Snackbar.Add("Not authorized to access admin portal.", Severity.Warning);
                }
                else if (ex.StatusCode == 400)
                {
                    _Snackbar.Add("Not authorized to access admin portal.", Severity.Warning);
                    _NavigationManager.NavigateTo("/forget-password");
                }
                else
                {
                    // Handle other exceptions (e.g., network errors, server errors)
                    _Snackbar.Add("An unexpected error occurred. Please try again later.", Severity.Error);
                    
                }
            }
            catch (Exception)
            {
                // Handle generic exceptions (fallback)
                _Snackbar.Add("An unexpected error occurred. Please try again later.", Severity.Error);
            }

            IsLoading = false;
        }

    }


    
}











//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.WebUtilities;
//using PMS.UI.Contracts.Repository_Interface;
//using PMS.UI.Models.Atuh;
//using PMS.UI.Models.Auth;
//using System.Web;

//namespace PMS.UI.Pages
//{
//    public partial class Register
//    {
//        public RegisterVM RegisterVM { get; set; } = new();

//        [Inject]
//        public NavigationManager _NavigationManager { get; set; }

//        public string Message { get; set; }

//        public bool EmailExists { get; set; }

//        [Inject]
//        private IAuthenticationService _AuthenticationService { get; set; }

//        protected override void OnInitialized()
//        {
//            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
//            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("firstName", out var firstName))
//            {
//                RegisterVM.FirstName = firstName;
//            }
//            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("lastName", out var lastName))
//            {
//                RegisterVM.LastName = lastName;
//            }
//            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("email", out var email))
//            {
//                RegisterVM.Email = email;
//            }
//            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("phoneNumber", out var phoneNumber))
//            {
//                RegisterVM.PhoneNumber = phoneNumber;
//            }
//        }

//        private async Task CheckEmailExistence()
//        {
//            if (!string.IsNullOrEmpty(RegisterVM.Email))
//            {
//                EmailExists = await _AuthenticationService.IsEmailRegisteredExist(RegisterVM.Email);
//            }
//        }

//        protected async Task HandleRegister()
//        {
//            if (EmailExists)
//            {
//                Message = "Email already exists.";
//                return;
//            }

//            var result = await _AuthenticationService.IsRegister(RegisterVM);

//            if (result)
//            {
//                _NavigationManager.NavigateTo("/");
//            }
//            else
//            {
//                Message = "Something went wrong, please try again.";
//                return;
//            }
//        }
//    }
//}
