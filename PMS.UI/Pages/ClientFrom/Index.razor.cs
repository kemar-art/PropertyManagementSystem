using Application.Contracts.Repository_Interface;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        public IFormRepository _FormRepository { get; set; }

        [Inject]
        public SweetAlertService Swal { get; set; }

        public IEnumerable<FormVM> FormVMs { get; private set; } = [];

        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        protected void FormEdit(int id)
        {
            _NavigationManager.NavigateTo($"/edit/{id}");
        }

        protected void FormDetails(int id)
        {
            _NavigationManager.NavigateTo($"/details/{id}");
        }

        protected async Task FormDeletion(int id)
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
                    FormVMs = await _FormRepository.GetAllForms();
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
            FormVMs = await _FormRepository.GetAllForms();
            IsLoading = false;
        }


    }
}
