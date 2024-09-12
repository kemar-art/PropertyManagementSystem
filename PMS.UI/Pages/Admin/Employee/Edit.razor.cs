using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;
using PMS.UI.Contracts;
using System.Reflection.Metadata;

namespace PMS.UI.Pages.Admin.Employee
{
    public partial class Edit
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;
        private bool IsLoading { get; set; } = true;
        public string Message { get; set; } = string.Empty;


        private IBrowserFile file;
        private string fileName;
        private long fileSize;


        [Inject]
        public IFormRepository _FormRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        IAdminRepository _AdminRepository { get; set; }

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        public ApplicationUserVM _editModel { get; set; } = new();

        //public DashBoardVM DashboardVM { get; set; } = new();

        IEnumerable<IdentityRole> _roles = [];

        IEnumerable<Region> Regions { get; set; } = [];

        private bool _isFirstRender = true;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true; // Ensure the loading overlay is displayed

            try
            {
                Regions = await _RegionRepositoey.GetAllRegion() ?? [];
                _roles = await _AdminRepository.GetRolesAsync();

                _editModel = await _AdminRepository.GetEmployeesById(UserId);

                _editModel.AdminRegionId = Regions.FirstOrDefault().Id;
                _editModel.RoleId = _roles.FirstOrDefault()?.Id;


            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                IsLoading = false; // Hide the loading overlay
                StateHasChanged();
            }
        }

        private async Task OnValidSubmit()
        {
            IsLoading = true;
            try
            {
                // Handle image update logic
                _editModel.ImagePath = file == null ? null : _editModel.ImagePath ?? string.Empty;

                var response = await _AdminRepository.UpdateBackOfficeUse(_editModel);

                if (response != null && response.IsSuccess)
                {
                    _Snackbar.Add(response.Value.Message, Severity.Success);
                    _NavigationManager.NavigateTo("/admin/employee/");
                }
                else
                {
                    _Snackbar.Add(response?.Error, Severity.Warning);
                }
            }
            catch (Exception ex)
            {
                _Snackbar.Add("An error occurred, please contact the administrator", Severity.Error);
            }
            finally
            {
                IsLoading = false;
            }
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

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{

        //}

        protected void BackToInex()
        {
            _NavigationManager.NavigateTo("/admin/employee/");
        }
    }
}