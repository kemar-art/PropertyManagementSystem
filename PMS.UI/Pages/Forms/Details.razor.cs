using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.Forms
{
    public partial class Details
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

        public FormVM _detailModel { get; set; } = new();

        IEnumerable<Region> Regions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                // Fetch all Purpose of Evaluation checkboxes
                var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
                // Fetch all Type of Property checkboxes
                var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();

                // Get form details, including previously checked items (if any)
                _detailModel = await _FormRepository.GetASingleFormDetails(FormId);

                // Set up checkboxes for Purpose of Valuation
                PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = _detailModel.PurposeOfValuationItemSelectedIds?.Split(',').Contains(vm.Id.ToString()) ?? false // Check based on selected IDs
                }).ToList();

                // Set up checkboxes for Type of Property
                TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    IsChecked = _detailModel.TypeOfPropertySelectedIds?.Split(',').Contains(vm.Id.ToString()) ?? false // Check based on selected IDs
                }).ToList();

                // Load regions (if required)
                Regions = await _RegionRepositoey.GetAllRegion() ?? [];

                
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message)
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        protected void BackToIndex()
        {
            _NavigationManager.NavigateTo("/submitted-forms/");
        }

        private void ConvertToUpperCase(string fieldName)
        {
            var propertyInfo = _detailModel.GetType().GetProperty(fieldName);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(_detailModel)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    propertyInfo.SetValue(_detailModel, value.ToUpper());
                }
            }
        }
    }
}