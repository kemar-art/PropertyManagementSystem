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

namespace PMS.UI.Pages.Forms
{
    public partial class Tracking
    {
        string selectedStep = string.Empty;

        private bool IsLoading { get; set; } = true;

        public string SearchString { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string CancelledMessage { get; set; } = string.Empty;

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
                if (_trackingModel == null)
                {
                    _trackingModel = new FormVM();
                }

                if (int.TryParse(SearchString, out int searchId))
                {
                    _trackingModel.Status = await _FormRepository.TrackForm(searchId);

                    if (string.IsNullOrEmpty(_trackingModel.Status))
                    {
                        Message = "No record was found.";
                    }
                    else
                    {
                        if (_trackingModel.Status == FormStatus.StatusCancelled)
                        {
                            Message = "The job has been cancelled.";
                            StateHasChanged(); // Trigger UI refresh after setting the message
                        }
                        else
                        {
                            await OnSelectedStepChanged(_trackingModel.Status);
                        }
                    }
                }
                else
                {
                    Message = "No tracking ID was entered.";
                    _trackingModel.Status = string.Empty;
                }
            }
            catch (Exception)
            {
                Message = "No record was found.";
                _trackingModel.Status = string.Empty;
            }
            finally
            {
                IsLoading = false;
            }
        }


        private Task OnSelectedStepChanged(string formStatus)
        {
            // If the status is within the "In Process" group, keep the step at "In Process"
            if (formStatus == FormStatus.StatusInProcess ||
                formStatus == FormStatus.StatusSubmitForApproval ||
                formStatus == FormStatus.StatusReturnToAppraiser ||
                formStatus == FormStatus.StatusApproved)
            {
                selectedStep = FormStatus.StatusInProcess;  // Stay on the third step
            }
            else if (formStatus == FormStatus.StatusAccepted ||
                     formStatus == FormStatus.StatusRejected)
            {
                selectedStep = FormStatus.StatusAssigned;
            }
            else
            {
                selectedStep = formStatus;  // Move to the appropriate step for other statuses
            }

            StateHasChanged();  // Trigger UI refresh when the step changes
            return Task.CompletedTask;
        }

        private bool NavigationAllowed(StepNavigationContext context)
        {
            // Only allow navigation to the current step based on FormVM.Status
            return context.NextStepName == _trackingModel.Status;
        }

        private bool IsStepCompleted(string stepName)
        {
            var stepsOrder = new List<string>
            {
                FormStatus.StatusSubmitted,
                FormStatus.StatusAssigned,
                FormStatus.StatusInProcess,
                FormStatus.StatusSubmitForApproval,
                FormStatus.StatusReturnToAppraiser,
                FormStatus.StatusApproved,
                FormStatus.StatusCompleted
            };

            int currentStepIndex = stepsOrder.IndexOf(_trackingModel.Status);
            int stepIndex = stepsOrder.IndexOf(stepName);

            // If the form is in StatusAccepted or StatusRejected, only mark the first step (StatusSubmitted) as completed
            if (_trackingModel.Status == FormStatus.StatusAccepted ||
                _trackingModel.Status == FormStatus.StatusRejected)
            {
                return stepIndex < stepsOrder.IndexOf(FormStatus.StatusAssigned);
            }

            // When the status is StatusSubmitForApproval or StatusReturnToAppraiser, gray out previous steps
            if (_trackingModel.Status == FormStatus.StatusSubmitForApproval ||
                _trackingModel.Status == FormStatus.StatusApproved ||
                _trackingModel.Status == FormStatus.StatusReturnToAppraiser)
            {
                return stepIndex < stepsOrder.IndexOf(FormStatus.StatusInProcess);
            }

            // For other statuses, mark a step as completed if its index is less than or equal to the current step's index
            return stepIndex <= currentStepIndex;
        }


        private bool IsInProcessStepCompleted()
        {
            // Only allow marking "In Process" as completed when the status is beyond "In Process" (Completed)
            return _trackingModel.Status == FormStatus.StatusCompleted;
        }






    }

}