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
    public partial class ForgotPassword
    {
        public ForgetPassword _forgetPasswordModel { get; set; }

        [Inject]
        public IAuthenticationService _AuthenticationService { get; set; }

        [Inject]
        NavigationManager _NavigationManager { get; set; }


        public string Message { get; set; } = string.Empty;
        private bool IsLoading { get; set; } = true;

        protected override void OnInitialized()
        {
            IsLoading = true;
            _forgetPasswordModel = new ForgetPassword();
            IsLoading = false;
        }


        protected async Task OnValidSubmit()
        {
            IsLoading = true;

            var sendEmailToResetPassword = await _AuthenticationService.ForgetPassword(_forgetPasswordModel);
            if (sendEmailToResetPassword.Exists)
            {
                // Navigate to the home page or any other page
                Message = sendEmailToResetPassword.Message;
                _NavigationManager.NavigateTo("/forget-password");
            }
            else
            {
                Message = sendEmailToResetPassword.Message;
                _NavigationManager.NavigateTo("/forget-password");
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
