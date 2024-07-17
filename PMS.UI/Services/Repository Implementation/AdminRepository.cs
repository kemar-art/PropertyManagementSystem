using AutoMapper;
using Blazored.LocalStorage;
using PMS.UI.Contracts;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class AdminRepository : BaseHttpService, IAdminRepository
    {
        private readonly IMapper _mapper;

        public AdminRepository(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
            //this is to be added to all out going calls to API
            //await AddBearerToken();
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
    }
}
