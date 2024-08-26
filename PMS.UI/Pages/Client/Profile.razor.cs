using Blazorise.DeepCloner;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Auth;
using PMS.UI.Models.Client;
using PMS.UI.Services.Base;
using System;
using System.Threading.Tasks;

namespace PMS.UI.Pages.Client
{
    public partial class Profile
    {
        private bool IsLoading { get; set; } = true;

        private bool IsEditMode { get; set; } = false;

        public string UserId { get; set; } = string.Empty;

        private IBrowserFile file;
        private string fileName;
        private long fileSize;

        IEnumerable<Region> Regions { get; set; }

        public ClientVM _profileModel { get; set; } = new();

        private EditContext _editContext;

        private ValidationMessageStore _validationMessageStore;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IClientRepository _ClientRepository { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        private ClientVM _originalProfileModel;

        protected override async Task OnInitializedAsync()
        {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            _editContext = new EditContext(_profileModel);
            _validationMessageStore = new ValidationMessageStore(_editContext);

            if (user.Identity.IsAuthenticated)
            {
                var userIdClaim = user.FindFirst("uid");
                if (userIdClaim != null)
                {
                    UserId = userIdClaim.Value;

                    IsLoading = true;
                    _profileModel = await _ClientRepository.GetClientById(UserId);

                    // Store a copy of the original profile
                    _originalProfileModel = _profileModel.DeepClone();

                    // Ensure ImageBase64 is null or empty string if no image is uploaded
                    if (string.IsNullOrEmpty(_profileModel.ImageBase64))
                    {
                        _profileModel.ImageBase64 = null; // or string.Empty
                    }

                    Regions = await _RegionRepositoey.GetAllRegion() ?? [];

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

        protected async Task OnValidSubmit()
        {
            IsLoading = true;

            // Handle image update logic
            _profileModel.ImagePath = file == null ? null : _profileModel.ImagePath ?? string.Empty;

            // Set the user ID before updating the profile
            _profileModel.Id = UserId;

            // Update the client profile and switch back to view mode
            await _ClientRepository.UpdateClient(_profileModel);
            ToggleEditMode();

            // Display success message and navigate back to the profile page
            _Snackbar.Add("Your profile was updated successfully.", Severity.Success);
            _NavigationManager.NavigateTo("/profile");

            IsLoading = false;
        }


        private void CancelEdit()
        {
            // Reset _profileModel to its original state using the stored copy
            _profileModel = _originalProfileModel.DeepClone();

            IsEditMode = false; // Exit edit mode
        }

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
                _profileModel.ImagePath = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";

                // Update ImageBase64 with the same data for immediate display
                _profileModel.ImageBase64 = _profileModel.ImagePath;
            }
            catch (Exception)
            {
                // Display error notification
                _Snackbar.Add($"An error occurred while uploading the file", Severity.Error);
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

        private void ConvertToUpperCase(string fieldName)
        {
            var propertyInfo = _profileModel.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(_profileModel)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    propertyInfo.SetValue(_profileModel, value.ToUpper());
                }
            }
        }


    }
}
