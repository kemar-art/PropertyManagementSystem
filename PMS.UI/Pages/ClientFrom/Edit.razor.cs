using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Edit
    {
        [Parameter]
        public Guid FormId { get; set; }

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
            var form = await _FormRepository.GetASingleFormDetails(FormId);
            FormVM = form;

            var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
            ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = form.ServiceRequestItemSelectId.ConvertStringToListOfInt().Contains(vm.Id)
            }).ToList();

            var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
            PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = form.PurposeOfValuationItemSelectedIds.ConvertStringToListOfInt().Contains(vm.Id)
            }).ToList();

            var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
            TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
            {
                Id = vm.Id,
                Title = vm.Title,
                IsChecked = form.TypeOfPropertySelectedIds.ConvertStringToListOfInt().Contains(vm.Id)
            }).ToList();

            Regions = await _RegionRepositoey.GetAllRegion();

            IsLoading = false;
        }

        private async Task OnValidSubmit()
        {
            FormVM.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(x => x.IsChecked).Select(x => x.Id));
            FormVM.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(x => x.IsChecked).Select(x => x.Id));
            FormVM.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(x => x.IsChecked).Select(x => x.Id));

            var response = await _FormRepository.UpdateForm(FormVM);

            if (response.Success)
            {
                _NavigationManager.NavigateTo("/submitted-forms"); // Redirect to the forms list page or any success page
            }
            else
            {
                // Handle error
            }
        }

    }
}