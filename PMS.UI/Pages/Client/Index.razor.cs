using Application.Contracts.Repository_Interface;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Client
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        public IFormRepository _FormRepository { get; set; }

        [Inject]
        public SweetAlertService Swal { get; set; }

        public IEnumerable<FormVM> _indexModel { get; private set; } = [];

        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        protected void FormEdit(Guid id)
        {
            _NavigationManager.NavigateTo($"/edit/{id}");
        }

        protected void FormDetails(Guid id)
        {
            _NavigationManager.NavigateTo($"/details/{id}");
        }

        protected async Task FormDeletion(Guid id)
        {
            var result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "You won't be able to revert this!",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonColor = "#d33",
                CancelButtonColor = "#008000",
                ConfirmButtonText = "Yes, delete it!"
            });
            if (result.IsConfirmed)
            {
                var response = await _FormRepository.DeleteForm(id);
                if (response.Success)
                {
                    // Refresh the data after deletion
                    _indexModel = await _FormRepository.GetAllForms();
                    StateHasChanged();
                }
                else
                {
                    Message = response.Message;
                }
            }
        }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true; // Ensure the loading overlay is displayed
            try
            {
                _indexModel = await _FormRepository.GetAllForms();

            }
            catch (Exception ex)
            {
                //This is to be logged this most not be seen by the user on developer
                Message = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false; // Hide the loading overlay
            }

        }



    }
}
