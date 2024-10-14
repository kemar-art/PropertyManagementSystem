using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Client;
using Blazorise.DeepCloner;
using PMS.UI.Services.Base;
using PMS.UI.Models.Employee;
using PMS.UI.Contracts;
using Microsoft.JSInterop;

namespace PMS.UI.Pages.Admin.Employee
{
    public partial class Details
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        private bool IsEditMode { get; set; } = false;

        //public string UserId { get; set; } = string.Empty;

        private IBrowserFile file;
        private string fileName;
        private long fileSize;

        IEnumerable<Region> Regions { get; set; }

        public ApplicationUserVM _detailsModel { get; set; } = new();

        private EditContext _editContext;

        private ValidationMessageStore _validationMessageStore;

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IAdminRepository _AdminRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ISnackbar _Snackbar { get; set; }

        [Inject]
        IJSRuntime _JSRuntime { get; set; }


        private ApplicationUserVM _originalProfileModel;

        IEnumerable<IdentityRole> _roles = [];

        protected override async Task OnInitializedAsync()
        {

            Regions = await _RegionRepositoey.GetAllRegion() ?? [];
            _roles = await _AdminRepository.GetRolesAsync();

            IsLoading = true;
            _detailsModel = await _AdminRepository.GetEmployeesById(UserId);

            _detailsModel.AdminRegionId = Regions.FirstOrDefault().Id;
            _detailsModel.RoleId = _roles.FirstOrDefault().Id;

            // Ensure ImageBase64 is null or empty string if no image is uploaded
            if (string.IsNullOrEmpty(_detailsModel.ImageBase64))
            {
                _detailsModel.ImageBase64 = null; // or string.Empty
            }

            Regions = await _RegionRepositoey.GetAllRegion() ?? [];

            IsLoading = false;

        }
        private void BackToIndex()
        {
            _NavigationManager.NavigateTo("/admin/employee/");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await OnInitializedAsync();
                // Call the JS function to reload the vendor script
                await _JSRuntime.InvokeVoidAsync("reloadVendorScript");
            }
        }
    }
}