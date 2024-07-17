using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Create
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        public FormVM FormVM { get; set; } = new();

        //protected override Task OnInitializedAsync()
        //{

        //}

        private async Task HandleValidSubmit()
        {
            await _FormRepository.CreateForm(FormVM);
            _NavigationManager.NavigateTo("/submitted-successfully/");
        }
    }
}