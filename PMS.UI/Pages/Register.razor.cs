using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using PMS.UI.Models.Client;
using System.Threading.Tasks;

namespace PMS.UI.Pages
{
    public partial class Register
    {
        public RegisterVM _registerModel { get; set; } = new();

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
                _registerModel.FirstName = firstName;
            }
            if (queryParams.TryGetValue("lastName", out var lastName))
            {
                _registerModel.LastName = lastName;
            }
            if (queryParams.TryGetValue("email", out var email))
            {
                _registerModel.Email = email;
                IsEmailDisabled = true;
            }
            if (queryParams.TryGetValue("regionId", out var clientRejoinId))
            {
                if (Guid.TryParse(clientRejoinId, out var regionGuid))
                {
                    _registerModel.ClientRegionId = regionGuid;
                }
            }
            if (queryParams.TryGetValue("phoneNumber", out var phoneNumber))
            {
                _registerModel.PhoneNumber = phoneNumber;
            }
            if (queryParams.TryGetValue("address", out var address))
            {
                _registerModel.Address = address;
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

        private async Task CheckEmailExistence()
        {
            if (!string.IsNullOrEmpty(_registerModel.Email))
            {
                EmailExists = await _AuthenticationService.IsEmailRegisteredExist(_registerModel.Email);
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

            //_registerModel.ClientRegionId = _registerModel.ClientRegionId;

            var result = await _AuthenticationService.IsRegister(_registerModel);

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





