using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IClientRepository
    {
        Task<ClientVM> GetClientById(string uerId);
        Task UpdateClient(ClientVM user);
    }
}
