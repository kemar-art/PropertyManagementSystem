using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Contracts
{
    public interface IAdminRepository
    {
        Task<AppResponseBaseResult> CreateBackOfficeUser(ApplicationUserVM userToCreate);
        Task<IEnumerable<ApplicationUserVM>> GetAllClients();
        Task<IEnumerable<ApplicationUserVM>> GetAllEmployees();
        Task<ApplicationUserVM> GetEmployeesById(string uerId);
        Task<Response<Guid>> DeleteEmployee(string uerId);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
