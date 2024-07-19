using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Create
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }

        [Inject]
        IRegionRepositoey _RegionRepositoey { get; set; }

        [Inject]
        ICheckBoxRepository _CheckBoxRepository { get; set; }
        private bool IsLoading { get; set; } = true;

        public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = [];

        public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = [];

        public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = [];

        public FormVM FormVM { get; set; } = new();

        IEnumerable<Region> Regions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
            ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = vm.IsChecked

            }).ToList();

            var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
            PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = vm.IsChecked
            }).ToList();

            var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
            TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = vm.IsChecked
            }).ToList();

            Regions = await _RegionRepositoey.GetAllRegion();



            IsLoading = false;
    }

        private async Task HandleValidSubmit()
        {
            await _FormRepository.CreateForm(FormVM);

            //_NavigationManager.NavigateTo("/submitted-successfully/");
        }
    }
}