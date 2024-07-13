using Blazored.LocalStorage;
using PMS.UI.Contracts;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class AppraiserRerpository : BaseHttpService, IAppraiserRerpository
    {
        public AppraiserRerpository(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
