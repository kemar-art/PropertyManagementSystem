using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;

namespace PMS.UI.Pages.ClientForm
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _NavigationManager { get; set; }

        [Inject]
        public IFormRepository _FormRepository { get; set; }

        public IEnumerable<FormVM> FormVMs { get; private set; } = Enumerable.Empty<FormVM>();

        public string Message {  get; set; } = string.Empty;

        protected void FormEdit(int id)
        {
            _NavigationManager.NavigateTo($"/submitted-forms/edit/{id}");
        }

        protected void FormDetails(int id)
        {
            _NavigationManager.NavigateTo($"/submitted-forms/details/{id}");
        }

        protected async Task FormDeletion(int id)
        {
            var response = await _FormRepository.DeleteForm(id);
            if(response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            FormVMs = await _FormRepository.GetAllForms();
        }
    }
}