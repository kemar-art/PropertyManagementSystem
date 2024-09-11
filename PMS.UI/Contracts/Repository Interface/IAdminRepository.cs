using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Contracts
{
    public interface IAdminRepository
    {
        Task<AppResponseBaseResult> CreateBackOfficeUser(ApplicationUserVM userToCreate);
        Task<IEnumerable<ClientVM>> GetAllClients();
        Task<IEnumerable<ApplicationUserVM>> GetAllEmployees();
        Task<ApplicationUserVM> GetEmployeesById(string uerId);
        Task DeleteEmployee(string uerId);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
