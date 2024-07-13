using Blazored.LocalStorage;
using PMS.UI.Contracts;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class AdminRepository : BaseHttpService, IAdminRepository
    {
        public AdminRepository(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
