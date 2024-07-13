using AutoMapper;
using Blazored.LocalStorage;
using PMS.UI.Contracts;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class FormRepository : BaseHttpService, IFormRepository
    {
        private readonly IMapper _mapper;
        public FormRepository(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateForm(FormVM form)
        {
            try
            {
                var createFormCommand = _mapper.Map<CreateFormCommand>(form);
                await _client.FormsPOSTAsync(createFormCommand);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteForm(int id)
        {
            try
            {
                await _client.FormsDELETEAsync(id);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<IEnumerable<FormVM>> GetAllForms()
        {
            var getAllForms = await _client.FormsAllAsync();
            return _mapper.Map<IEnumerable<FormVM>>(getAllForms);
        }

        public async Task<FormVM> GetASingleFormDetails(int id)
        {
            var getASingleForm = await _client.FormsGETAsync(id);
            return _mapper.Map<FormVM>(getASingleForm);
        }

        public async Task<Response<Guid>> UpdateForm(FormVM form)
        {
            try
            {
                var updateFormCommand = _mapper.Map<UpdateFormCommand>(form);
                await _client.FormsPUTAsync(updateFormCommand);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
