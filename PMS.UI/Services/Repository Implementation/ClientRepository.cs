using AutoMapper;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Client;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class ClientRepository : BaseHttpService, IClientRepository
    {
        private readonly IMapper _mapper;

        public ClientRepository(IClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage, IMapper mapper) : base(client, localStorage, sessionStorage)
        {
            _mapper = mapper;
        }

        public async Task<ClientVM> GetClientById(string uerId)
        {
            var getClient = await _client.ApplicationUsersGETAsync(uerId);
            return _mapper.Map<ClientVM>(getClient);
        }

        public async Task UpdateClient(ClientVM user)
        {
            ClientUpdateCommand command = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Address = user.Address,
            };

            
        }

    }
}
