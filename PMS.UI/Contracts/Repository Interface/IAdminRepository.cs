using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Contracts
{
    public interface IAdminRepository
    {
        Task<CustomResponseBaseResult> CreateBackOfficeUser(ApplicationUserVM userToCreate);
        Task<IEnumerable<ClientVM>> GetAllClients();
        Task<IEnumerable<ApplicationUserVM>> GetAllEmployees();
        Task<ApplicationUserVM> GetEmployeesById(string uerId);
        Task<CustomResponse> DeleteEmployee(string uerId);
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
