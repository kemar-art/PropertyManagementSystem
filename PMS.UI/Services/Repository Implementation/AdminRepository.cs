using AutoMapper;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using PMS.UI.Contracts;
using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.UI.Services.Repository_Implementation
{
    public class AdminRepository : BaseHttpService, IAdminRepository
    {
        private readonly IMapper _mapper;

        public AdminRepository(IClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage, IMapper mapper) : base(client, localStorage, sessionStorage)
        {
            _mapper = mapper;
            //this is to be added to all out going calls to API
            //await AddBearerToken();
        }

        public async Task<CustomResponseBaseResult> CreateBackOfficeUser(ApplicationUserVM user)
        {
            CreateBackOfficeUserCommand createBackOfficeUser = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                TaxRegistrationNumber = user.TaxRegistrationNumber,
                NationalInsuranceScheme = user.NationalInsuranceScheme,
                Gender = user.Gender,
                ImagePath = user.ImagePath,
                DateOfBirth = user.DateOfBirth,
                DateRegistered = user.DateRegistered,
                RoleId = user.RoleId,
                AdminRegionId = user.AdminRegionId,
            };
            var response = await _client.ApplicationUsersPOSTAsync(createBackOfficeUser);
            return response;
        }

        public async Task<CustomResponse> DeleteEmployee(string uerId)
        {
            var response = await _client.ApplicationUsersDELETEAsync(uerId);
            return response;
        }

        public async Task<IEnumerable<ClientVM>> GetAllClients()
        {
            var getAllEmployees = await _client.ClietsAsync();
            return _mapper.Map<IEnumerable<ClientVM>>(getAllEmployees);
        }

        public async Task<IEnumerable<ApplicationUserVM>> GetAllEmployees()
        {
            var getAllEmployees = await _client.AdminsAsync();
            return _mapper.Map<IEnumerable<ApplicationUserVM>>(getAllEmployees);
        }

        public async Task<ApplicationUserVM> GetEmployeesById(string uerId)
        {
            var getEmployee = await _client.ApplicationUsersGETAsync(uerId);
            return _mapper.Map<ApplicationUserVM>(getEmployee);
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            var roles = await _client.RolesAsync();
            return roles;
        }

        public async Task<CustomResponseBaseResult> UpdateBackOfficeUse(ApplicationUserVM user)
        {
            var mapUser = _mapper.Map<UpdateBackOfficeUserCommand>(user);
            var response = await _client.ApplicationUsersPUTAsync(mapUser);
            return response;
        }
    }
}
