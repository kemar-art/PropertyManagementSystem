using AutoMapper;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
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

            var updateUser = _mapper.Map<ClientUpdateCommand>(user);


            //ClientUpdateCommand command = new()
            //{
            //    Id = user.Id, // Ensure the ID is included
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Email = user.Email,
            //    PhoneNumber = user.PhoneNumber,
            //    Gender = user.Gender, // Ensure Gender is included if required
            //    Address = user.Address,
            //    ImagePath = user.ImagePath,
            //    DateOfBirth = user.DateOfBirth, // Ensure DateOfBirth is included if required
            //    RegionId = user.RegionId,
            //};

            await _client.UpdateclientAsync(updateUser);
        }




    }
}
