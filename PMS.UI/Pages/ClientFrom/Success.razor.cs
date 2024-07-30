using AutoMapper;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Success
    {
        [Inject]
        private IFormRepository _FormRepository { get; set; }

        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        private IMapper _Mapper { get; set; }

        public FormVM FormVM { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //if (Id == 0)
            //{
            //    // Handle the case where ID is not provided
            //    _NavigationManager.NavigateTo("/error"); // Redirect to an error page or show an error message
            //    return;
            //}

            var getFormThatWasSubmitted = await _FormRepository.GetASingleFormDetails(Id);
            if (getFormThatWasSubmitted == null)
            {
                // Handle the case where the form was not found
                _NavigationManager.NavigateTo("/error"); // Redirect to an error page or show an error message
                return;
            }

            FormVM = _Mapper.Map<FormVM>(getFormThatWasSubmitted);
        }
    }
}