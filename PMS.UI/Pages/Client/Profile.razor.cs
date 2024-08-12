using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using PMS.UI.Models.Client;
using System.Threading.Tasks;

namespace PMS.UI.Pages.Client
{
    public partial class Profile
    {
        public ClientVM _profileModel { get; set; } = new();

        public string UserId { get; set; } = string.Empty;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IClientRepository _ClientRepository { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        private bool IsLoading { get; set; } = true;
        private bool IsEditMode { get; set; } = false;

        protected override async Task OnInitializedAsync()
          {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var userIdClaim = user.FindFirst("uid");
                if (userIdClaim != null)
                {
                    UserId = userIdClaim.Value;

                    IsLoading = true;
                    _profileModel = await _ClientRepository.GetClientById(UserId);
                    IsLoading = false;
                }
                else
                {
                    // Handle case where "uid" claim is missing
                    _NavigationManager.NavigateTo("/login");
                }
            }
            else
            {
                // User is not authenticated, redirect to login page
                _NavigationManager.NavigateTo("/login");
            }
        }

        private void ToggleEditMode()
        {
            IsEditMode = !IsEditMode;
        }

        private void PasswordReset()
        {
            _NavigationManager.NavigateTo("/update-password");
        }

        protected async Task OnValidSubmit()
        {
            IsLoading = true;

            // Perform update logic here
            await _ClientRepository.UpdateClient(_profileModel);
            IsLoading = false;

            _NavigationManager.NavigateTo("/profile");
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
