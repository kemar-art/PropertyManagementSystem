using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PMS.UI.Contracts;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.DashBoard;
using PMS.UI.Models.Form;
using PMS.UI.StaticDetails;

namespace PMS.UI.Pages.Admin.Dashboard
{
    public partial class Index
    {
        private bool IsLoading { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        [Inject]
        public IFormRepository _FormRepository { get; set; }

        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        public DashBoardVM DashboardVM { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true; // Ensure the loading overlay is displayed
            try
            {
                var Completed = await _FormRepository.GetFromCount(FormStatus.StatusCompleted);
                var Inprocess = await _FormRepository.GetFromCount(FormStatus.StatusInProcess);
                var Accepted = await _FormRepository.GetFromCount(FormStatus.StatusAccepted);
                var Rejected = await _FormRepository.GetFromCount(FormStatus.StatusRejected);
                DashboardVM = new()
                {
                    Completed = Completed,
                    Inprocess = Inprocess,
                    Accepted = Accepted,
                    Rejected = Rejected
                };
            }
            catch (Exception ex)
            {
                // Log error
                Message = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false; // Hide the loading overlay
                StateHasChanged();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await OnInitializedAsync();
                // Call the JS function to reload the vendor script
                //await jSRuntime.InvokeVoidAsync("reloadVendorScript");
            }
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{

        //}
    }

}