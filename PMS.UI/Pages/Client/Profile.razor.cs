using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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

        private IBrowserFile file;
        private string fileName;
        private long fileSize;


        private async Task UploadFile(IBrowserFile file)
        {
            this.file = file;
            fileName = file.Name;
            fileSize = file.Size;

            try
            {
                using var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                // Convert the MemoryStream to a byte array
                var buffer = memoryStream.ToArray();

                // Convert byte array to Base64 string and set it to the profile model
                _profileModel.ImageBase64 = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while uploading the file: {ex.Message}");
            }
        }


        //private async Task UploadFile(IBrowserFile file)
        //{
        //    this.file = file;
        //    fileName = file.Name;
        //    fileSize = file.Size;

        //    const long MaxAllowedSize = 1024 * 1024 * 15; // 15MB limit
        //    if (file.Size > MaxAllowedSize)
        //    {
        //        throw new InvalidOperationException($"File size exceeds the allowed limit of {MaxAllowedSize / (1024 * 1024)}MB.");
        //    }

        //    try
        //    {
        //        var buffer = new byte[file.Size];
        //        using var stream = file.OpenReadStream(MaxAllowedSize);
        //        await stream.ReadAsync(buffer);

        //        // Convert byte array to Base64 string and set it to the profile model
        //        _profileModel.ImageBase64 = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred while uploading the file: {ex.Message}");
        //    }
        //}

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

                    // Ensure ImageBase64 is null or empty string if no image is uploaded
                    if (string.IsNullOrEmpty(_profileModel.ImageBase64))
                    {
                        _profileModel.ImageBase64 = null; // or string.Empty
                    }

                    IsLoading = false;
                }
                else
                {
                    _NavigationManager.NavigateTo("/login");
                }
            }
            else
            {
                _NavigationManager.NavigateTo("/login");
            }
        }

        private void CancelEdit()
        {
            // Optionally, reset _profileModel to its original state if needed.
            // This assumes you have a way to revert changes or reload the original profile.

            //_profileModel = /* Code to reload the original profile */;

            IsEditMode = false; // Exit edit mode
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

            _profileModel.ImageBase64 = _profileModel.ImageBase64 ?? string.Empty;
            _profileModel.Id = UserId;

            await _ClientRepository.UpdateClient(_profileModel);
            IsLoading = false;

            ToggleEditMode(); // Switch back to view mode after saving
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
