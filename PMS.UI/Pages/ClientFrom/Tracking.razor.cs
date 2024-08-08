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
        IFormRepository _FormRepository { get; set; }
        private bool IsLoading { get; set; } = true;

        public string SearchString { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

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
            Message = string.Empty;
            selectedStep = string.Empty;

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

                    if (string.IsNullOrEmpty(FormVM.Status))
                    {
                        Message = "No record was found.";
                    }
                    else
                    {
                        await OnSelectedStepChanged(FormVM.Status);
                    }
                }
                else
                {
                    // Handle invalid search ID format
                    Message = "No tracking ID was entered.";
                    FormVM.Status = string.Empty;
                }
            }
            catch (Exception)
            {
                // Handle any exceptions that occur
                Message = "No record was found.";
                FormVM.Status = string.Empty;
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