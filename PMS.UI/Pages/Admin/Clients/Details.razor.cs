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

        public ClientVM _editdetailsModel { get; set; } = new();

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

        protected override async Task OnInitializedAsync()
        {

            IsLoading = true;
            _editdetailsModel = await _ClientRepository.GetClientById(UserId);



            // Ensure ImageBase64 is null or empty string if no image is uploaded
            if (string.IsNullOrEmpty(_editdetailsModel.ImageBase64))
            {
                _editdetailsModel.ImageBase64 = null; // or string.Empty
            }

            Regions = await _RegionRepositoey.GetAllRegion() ?? [];

            IsLoading = false;

        }

        private void BackToIndex()
        {
            _NavigationManager.NavigateTo("/admin/client/");
        }  
    }
}