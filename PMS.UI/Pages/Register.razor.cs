using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using System.Threading.Tasks;

namespace PMS.UI.Pages
{
    public partial class Register
    {
        public RegisterVM RegisterVM { get; set; } = new();

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool EmailExists { get; set; }
        public bool IsEmailDisabled { get; set; } = true;

        [Inject]
        private IAuthenticationService _AuthenticationService { get; set; }

        private bool IsLoading { get; set; } = true;

        protected override void OnInitialized()
        {
            IsLoading = true;
            var uri = _NavigationManager.ToAbsoluteUri(_NavigationManager.Uri);
            var queryParams = QueryHelpers.ParseQuery(uri.Query);

            if (queryParams.TryGetValue("firstName", out var firstName))
            {
                RegisterVM.FirstName = firstName;
            }
            if (queryParams.TryGetValue("lastName", out var lastName))
            {
                RegisterVM.LastName = lastName;
            }
            if (queryParams.TryGetValue("email", out var email))
            {
                RegisterVM.Email = email;
                IsEmailDisabled = true;
            }
            else
            {
                IsEmailDisabled = false;
            }
            if (queryParams.TryGetValue("phoneNumber", out var phoneNumber))
            {
                RegisterVM.PhoneNumber = phoneNumber;
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

        private async Task CheckEmailExistence()
        {
            if (!string.IsNullOrEmpty(RegisterVM.Email))
            {
                EmailExists = await _AuthenticationService.IsEmailRegisteredExist(RegisterVM.Email);
            }
        }

        protected async Task OnValidSubmit()
        {
            await CheckEmailExistence();

            if (EmailExists)
            {
                Message = "Email already exists.";
                return;
            }

            IsLoading = true;
            var result = await _AuthenticationService.IsRegister(RegisterVM);

            if (result)
            {
                _NavigationManager.NavigateTo("/login");
            }
            else
            {
                Message = "Something went wrong, please try again.";
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
