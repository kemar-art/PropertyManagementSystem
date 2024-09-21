using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Client;
using Blazorise.DeepCloner;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Admin.Clients
{
    public partial class Edit
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        private bool IsEditMode { get; set; } = false;

        private IBrowserFile file;
        private string fileName;
        private long fileSize;

        IEnumerable<Region> Regions { get; set; }

        public ClientVM _editModel { get; set; } = new();

        private EditContext _editContext;

        private ValidationMessageStore _validationMessageStore;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IClientRepository _ClientRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        private ClientVM _originalProfileModel;

        protected override async Task OnInitializedAsync()
        {


            _editContext = new EditContext(_editModel);
            _validationMessageStore = new ValidationMessageStore(_editContext);




            IsLoading = true;
            _editModel = await _ClientRepository.GetClientById(UserId);

            // Store a copy of the original profile
            _originalProfileModel = _editModel.DeepClone();

            // Ensure ImageBase64 is null or empty string if no image is uploaded
            if (string.IsNullOrEmpty(_editModel.ImageBase64))
            {
                _editModel.ImageBase64 = null; // or string.Empty
            }

            Regions = await _RegionRepositoey.GetAllRegion() ?? [];

            IsLoading = false;

        }

        protected async Task OnValidSubmit()
        {
            IsLoading = true;

            // Handle image update logic
            _editModel.ImagePath = file == null ? null : _editModel.ImagePath ?? string.Empty;

            // Set the user ID before updating the profile
            _editModel.Id = UserId;

            // Update the client profile and switch back to view mode
            await _ClientRepository.UpdateClient(_editModel);
            ToggleEditMode();

            // Display success message and navigate back to the profile page
            _Snackbar.Add("Your profile was updated successfully.", Severity.Success);
            _NavigationManager.NavigateTo("/admin/client/");

            IsLoading = false;
        }


        private void CancelEdit()
        {
            // Reset _editModel to its original state using the stored copy
            _editModel = _originalProfileModel.DeepClone();

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
                _editModel.ImagePath = $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";

                // Update ImageBase64 with the same data for immediate display
                _editModel.ImageBase64 = _editModel.ImagePath;
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

        private void BackToIndex()
        {
            _NavigationManager.NavigateTo("/admin/client/");
        }

        private void ConvertToUpperCase(string fieldName)
        {
            var propertyInfo = _editModel.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(_editModel)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    propertyInfo.SetValue(_editModel, value.ToUpper());
                }
            }
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        await OnInitializedAsync();
        //        // Call the JS function to reload the vendor script
        //        //await jSRuntime.InvokeVoidAsync("reloadVendorScript");
        //    }
        //}
    }
}