using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Pages.ClientFrom
{
    public partial class Tracking
    {
        [Inject]
        NavigationManager _NavigationManager { get; set; }

        [Inject]
        IFormRepository _FormRepository { get; set; }


        private bool IsLoading { get; set; } = true;

        public string SearchString { get; set; } = string.Empty;    

        public FormVM FormVM { get; set; }


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            FormVM = new FormVM();

            IsLoading = false;
        }



        private async Task OnValidSubmit()
        {
            IsLoading = true;

            try
            {
                // Initialize FormVM if it is null
                if (FormVM == null)
                {
                    FormVM = new FormVM();
                }

                // Check if the SearchString is valid
                if (int.TryParse(SearchString, out int searchId))
                {
                    // Call the repository method to track the form
                    FormVM.Status = await _FormRepository.TrackForm(searchId);

                }
                else
                {
                    // Handle invalid search ID format
                    FormVM.Status = "Invalid search ID format.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                FormVM.Status = $"An error occurred: {ex.Message}";
            }
            finally
            {
                // Ensure that the loading indicator is hidden
                IsLoading = false;
            }
        }




    }




    //public partial class Create
    //{
    //    [Inject]
    //    NavigationManager _NavigationManager { get; set; }

    //    [Inject]
    //    IFormRepository _FormRepository { get; set; }

    //    [Inject]
    //    IRegionRepositoey _RegionRepositoey { get; set; }

    //    [Inject]
    //    ICheckBoxRepository _CheckBoxRepository { get; set; }

    //    private bool IsLoading { get; set; } = true;

    //    public List<CheckBoxPropertyVM> TypeOfPropertyCheckBoxItemVM { get; set; } = new();

    //    public List<CheckBoxPropertyVM> ServiceRequestCheckBoxesVM { get; set; } = new();

    //    public List<CheckBoxPropertyVM> PurposeOfEvaluationCheckBoxesVM { get; set; } = new();

    //    public FormVM FormVM { get; set; } = new();

    //    IEnumerable<Region> Regions { get; set; } = new List<Region>();

    //    protected override async Task OnInitializedAsync()
    //    {
    //        IsLoading = true;

    //        try
    //        {
    //            var serviceRequests = await _CheckBoxRepository.GetAllServiceRequestItem();
    //            ServiceRequestCheckBoxesVM = serviceRequests.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            var purposeOfEvaluation = await _CheckBoxRepository.GetAllPurposeOfValuationItem();
    //            PurposeOfEvaluationCheckBoxesVM = purposeOfEvaluation.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            var typeOfProperty = await _CheckBoxRepository.GetAllTypeOfPropertyItem();
    //            TypeOfPropertyCheckBoxItemVM = typeOfProperty.Select(vm => new CheckBoxPropertyVM()
    //            {
    //                Id = vm.Id,
    //                Title = vm.Title,
    //                IsChecked = vm.IsChecked
    //            }).ToList();

    //            Regions = await _RegionRepositoey.GetAllRegion() ?? new List<Region>();
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle the exception (e.g., log it, show an error message)
    //            Console.WriteLine($"Error loading data: {ex.Message}");
    //        }
    //        finally
    //        {
    //            IsLoading = false;
    //        }
    //    }

    //    private async Task OnValidSubmit()
    //    {
    //        // Populate the selected IDs as comma-separated strings
    //        FormVM.TypeOfPropertySelectedIds = string.Join(",", TypeOfPropertyCheckBoxItemVM.Where(c => c.IsChecked).Select(c => c.Id));
    //        FormVM.ServiceRequestItemSelectId = string.Join(",", ServiceRequestCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));
    //        FormVM.PurposeOfValuationItemSelectedIds = string.Join(",", PurposeOfEvaluationCheckBoxesVM.Where(c => c.IsChecked).Select(c => c.Id));

    //        try
    //        {
    //            var response = await _FormRepository.CreateForm(FormVM);

    //            if (response.Success)
    //            {
    //                _NavigationManager.NavigateTo($"/success/{response.Data}");
    //            }
    //            else
    //            {
    //                // Handle error
    //                Console.WriteLine("Error: " + response.ErrorMessage);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Handle unexpected errors
    //            Console.WriteLine("Unexpected error: " + ex.Message);
    //        }
    //    }
    //}

}