using PMS.UI.Services.Base;

namespace Application.Contracts.Repository_Interface
{
    public interface ICheckBoxRepository
    {
        Task<List<ServiceRequestItem>> GetAllServiceRequestItem();
        Task<List<TypeOfPropertyItem>> GetAllTypeOfPropertyItem();
        Task<List<PurposeOfValuationItem>> GetAllPurposeOfValuationItem();
    }
}
