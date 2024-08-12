using AutoMapper;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;

namespace PMS.UI.Pages.Client
{
    public partial class Success
    {
        [Inject]
        private IFormRepository _FormRepository { get; set; }

        [Inject]
        private NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IMapper _Mapper { get; set; }

        public FormVM _successModel { get; set; }

        [Parameter]
        public Guid FormId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (FormId == Guid.Empty)
            {
                _NavigationManager.NavigateTo("/error");
                return;
            }

            var getFormThatWasSubmitted = await _FormRepository.GetASingleFormDetails(FormId);
            if (getFormThatWasSubmitted == null)
            {
                _NavigationManager.NavigateTo("/error");
                return;
            }

            _successModel = _Mapper.Map<FormVM>(getFormThatWasSubmitted);
        }
    }
}
