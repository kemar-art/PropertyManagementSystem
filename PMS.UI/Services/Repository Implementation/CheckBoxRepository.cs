using Application.Contracts.Repository_Interface;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using PMS.UI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class CheckBoxRepository : BaseHttpService, ICheckBoxRepository
    {
        public CheckBoxRepository(IClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage) : base(client, localStorage, sessionStorage)
        {
        }

        public async Task<List<PurposeOfValuationItem>> GetAllPurposeOfValuationItem()
        {
            var purposeOfValuationList = await _client.PurposeOfValuationItemsAsync();
            return [.. purposeOfValuationList];
        }

        public async Task<List<ServiceRequestItem>> GetAllServiceRequestItem()
        {
            var serviceRequestList = await _client.ServiceRequestItemsAsync();
            //if (serviceRequestList.Count == 0)
            //{
            //    throw new NotFoundException(serviceRequestList, )
            //}
            return [.. serviceRequestList];
        }

        public async Task<List<TypeOfPropertyItem>> GetAllTypeOfPropertyItem()
        {
            var typeOfPropertyList = await _client.TypeOfPropertyItemsAsync();
            return [.. typeOfPropertyList];
        }
    }
}
