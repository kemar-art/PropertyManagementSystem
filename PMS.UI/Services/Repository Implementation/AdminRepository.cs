using AutoMapper;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using PMS.UI.Contracts;
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

        public async Task<AppResponseBaseResult> CreateBackOfficeUser(ApplicationUserVM userToCreate)
        {
            CreateBackOfficeUserCommand createBackOfficeUser = new()
            {
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Address = userToCreate.Address,
                PhoneNumber = userToCreate.PhoneNumber,
                TaxRegistrationNumber = userToCreate.TaxRegistrationNumber,
                NationalInsuranceScheme = userToCreate.NationalInsuranceScheme,
                Gender = userToCreate.Gender,
                ImagePath = userToCreate.ImagePath,
                DateOfBirth = userToCreate.DateOfBirth,
                DateRegistered = userToCreate.DateRegistered,
                RoleId = userToCreate.RoleId,
                AdminRegionId = userToCreate.AdminRegionId,
            };
            var response = await _client.ApplicationUsersPOSTAsync(createBackOfficeUser); 
            return response;
        }

        public async Task<Response<Guid>> DeleteEmployee(string uerId)
        {
            try
            {
                await _client.ApplicationUsersDELETEAsync(uerId);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<IEnumerable<ApplicationUserVM>> GetAllEmployees()
        {
            var getAllEmployees = await _client.ApplicationUsersAllAsync();
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
    }
}
