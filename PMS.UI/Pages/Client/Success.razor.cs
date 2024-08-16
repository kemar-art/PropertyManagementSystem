using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;
using System.Security.Claims;

namespace PMS.UI.Pages.Client
{
    public partial class Success
    {
        public FormVM _successModel { get; set; } = new();

        public ClaimsPrincipal UserAuthstate { get; set; } = new();

        [Parameter]
        public Guid FormId { get; set; }

        [Inject]
        private IFormRepository _FormRepository { get; set; } 

        [Inject]
        private NavigationManager _NavigationManager { get; set; }

        [Inject]
        private AuthenticationStateProvider _AuthenticationStateProvider { get; set; }

        [Inject]
        private IMapper _Mapper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            UserAuthstate = authState.User;
             
            //if (user.Identity.IsAuthenticated)
            //{
            //    _NavigationManager.NavigateTo("/create/");
            //}

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
