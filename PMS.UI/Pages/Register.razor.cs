using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using PMS.UI.Models.Client;
using PMS.UI.Services.Base;
using System.Threading.Tasks;

namespace PMS.UI.Pages
{
    public partial class Register
    {
        public RegisterVM _registerModel { get; set; } = new();

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ISnackbar Snackbar { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool EmailExists { get; set; }
        public bool IsEmailDisabled { get; set; } = false;

        // Property to store custom validation error message
        public string RegionErrorMessage { get; set; } = string.Empty;

        [Inject]
        private IAuthenticationService _AuthenticationService { get; set; }

        IEnumerable<Region> Regions { get; set; } = [];

        private bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            Regions = await _RegionRepositoey.GetAllRegion() ?? [];
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
                IsEmailDisabled = true; // Disable the field if email is present initially
            }
            if (queryParams.TryGetValue("regionId", out var clientRejoinId))
            {
                if (Guid.TryParse(clientRejoinId, out var regionGuid))
                {
                    _registerModel.ClientRegionId = regionGuid;
                    IsEmailDisabled = true;
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

        

       

        protected async Task OnValidSubmit()
        {

            // Reset validation error message
            RegionErrorMessage = string.Empty;

            // Validate if the Parish (Region) is selected
            if (_registerModel.ClientRegionId == Guid.Empty)
            {
                RegionErrorMessage = "Parish is required.";
                return; // Stop form submission if Parish is not selected
            }


            await CheckEmailExistence();

            if (EmailExists)
            {
                //Message = "";
                Snackbar.Add("Email already exists.", Severity.Error);
                return;
            }

            IsLoading = true;

            var result = await _AuthenticationService.IsRegister(_registerModel);

            if (result)
            {
                Snackbar.Add("You have successfully registered.", Severity.Success);
                _NavigationManager.NavigateTo("/login");
            }
            else
            {
                Snackbar.Add("Something went wrong, please try again.", Severity.Error);
                //Message = "";
            }
            IsLoading = false;
        }

        private bool ValidateForm()
        {
            // Perform form validation (automatically validates via DataAnnotations)
            var editContext = new EditContext(_registerModel);
            return editContext.Validate();
        }


        private async Task CheckEmailExistence()
        {
            if (!string.IsNullOrEmpty(_registerModel.Email))
            {
                EmailExists = await _AuthenticationService.IsEmailRegisteredExist(_registerModel.Email);
            }
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





