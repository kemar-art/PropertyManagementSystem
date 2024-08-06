using Application.Contracts.Repository_Interface;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;
using PMS.UI.StaticDetails;
using System.Xml.Linq;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Tracking
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }


        private bool IsLoading { get; set; } = true;

        public string SearchString { get; set; } = string.Empty;

        public FormVM FormVM { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            FormVM = new FormVM();

            IsLoading = false;
        }

        string selectedStep = string.Empty;

        private bool NavigationAllowed(StepNavigationContext context)
        {
            // Only allow navigation to the current step based on FormVM.Status
            return context.NextStepName == FormVM.Status;
        }


        private async Task OnValidSubmit()
        {
            IsLoading = true;

            try
            {
                // Initialize FormVM if it is null
                if (FormVM == null)
                {
                    FormVM = new FormVM();
                }

                // Check if the SearchString is valid
                if (int.TryParse(SearchString, out int searchId))
                {
                    // Call the repository method to track the form
                    FormVM.Status = await _FormRepository.TrackForm(searchId);
                    await OnSelectedStepChanged(FormVM.Status);

                }
                else
                {
                    // Handle invalid search ID format
                    FormVM.Status = "Invalid search ID format.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                FormVM.Status = $"An error occurred: {ex.Message}";
            }
            finally
            {
                // Ensure that the loading indicator is hidden
                IsLoading = false;
            }
        }

        private Task OnSelectedStepChanged(string formStatus)
        {
            selectedStep = formStatus;

            return Task.CompletedTask;
        }
    }
}