using Application.Contracts.Repository_Interface;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Employee;
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

        //[Inject]
        //ICheckBoxRepository _CheckBoxRepository { get; set; }

        public IEnumerable<FormVM> _indexModel { get; private set; } = [];

        //public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = [];

        //public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = [];

        //public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = [];




        public string Message { get; set; } = string.Empty;

        private bool IsLoading { get; set; } = true;

        public string _searchString;

        // Quick filter across columns
        private Func<FormVM, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                return true;
            }

            return false;
        };





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
            IsLoading = true;
            try
            {
                //var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
                //PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
                //{
                //    Id = vm.Id,
                //    Title = vm.Title,
                //    IsChecked = vm.IsChecked
                //}).ToList();

                //var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
                //TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
                //{
                //    Id = vm.Id,
                //    Title = vm.Title,
                //    IsChecked = vm.IsChecked
                //}).ToList();

                // Retrieve forms and map checkbox titles
                _indexModel = await _FormRepository.GetAllForms();

                //foreach (var form in _indexModel)
                //{
                //    form.TypeOfPropertySelectedIds = string.Join(", ", TypeOfPropertyCheckBoxItemVM
                //        .Where(c => form.TypeOfPropertySelectedIds.Split(',').Contains(c.Id.ToString()))
                //        .Select(c => c.Title));

                //    form.PurposeOfValuationItemSelectedIds = string.Join(", ", PurposeOfEvaluationCheckBoxesVM
                //        .Where(c => form.PurposeOfValuationItemSelectedIds.Split(',').Contains(c.Id.ToString()))
                //        .Select(c => c.Title));
                //}
            }
            catch (Exception ex)
            {
                Message = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }




    }
}
