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

namespace PMS.UI.Pages.Client
{
    public partial class Tracking
    {
        string selectedStep = string.Empty;

        private bool IsLoading { get; set; } = true;

        public string SearchString { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public FormVM _trackingModel { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            _trackingModel = new FormVM();

            IsLoading = false;
        }

        private async Task OnValidSubmit()
        {
            IsLoading = true;
            Message = string.Empty;
            selectedStep = string.Empty;

            try
            {
                // Initialize FormVM if it is null
                if (_trackingModel == null)
                {
                    _trackingModel = new FormVM();
                }

                // Check if the SearchString is valid
                if (int.TryParse(SearchString, out int searchId))
                {
                    // Call the repository method to track the form
                    _trackingModel.Status = await _FormRepository.TrackForm(searchId);

                    if (string.IsNullOrEmpty(_trackingModel.Status))
                    {
                        Message = "No record was found.";
                    }
                    else
                    {
                        await OnSelectedStepChanged(_trackingModel.Status);
                    }
                }
                else
                {
                    // Handle invalid search ID format
                    Message = "No tracking ID was entered.";
                    _trackingModel.Status = string.Empty;
                }
            }
            catch (Exception)
            {
                // Handle any exceptions that occur
                Message = "No record was found.";
                _trackingModel.Status = string.Empty;
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

        private bool NavigationAllowed(StepNavigationContext context)
        {
            // Only allow navigation to the current step based on FormVM.Status
            return context.NextStepName == _trackingModel.Status;
        }
    }

}