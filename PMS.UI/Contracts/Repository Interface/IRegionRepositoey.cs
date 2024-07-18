using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IRegionRepositoey
    {
        Task<IEnumerable<Region>> GetAllRegion();
    }
}
