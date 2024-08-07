using AutoMapper;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using PMS.UI.Contracts;
using PMS.UI.Models;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class FormRepository : BaseHttpService, IFormRepository
    {
        private readonly IMapper _mapper;
        public FormRepository(IClient client, IMapper mapper, ILocalStorageService localStorage, ISessionStorageService sessionStorage) : base(client, localStorage, sessionStorage)
        {
            _mapper = mapper;
        }


        public async Task<Response<Guid>> CreateForm(FormVM form)
        {
            try
            {
                var createFormCommand = _mapper.Map<CreateFormCommand>(form);

                // Capture the payload for debugging (if needed)
                //var payload = JsonConvert.SerializeObject(createFormCommand);
                //Console.WriteLine("Payload: " + payload);

                // Assuming your API returns the form ID
                var formId = await _client.FormsPOSTAsync(createFormCommand);

                return new Response<Guid> { Success = true, Data = formId };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }


        public async Task<Response<Guid>> DeleteForm(Guid id)
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

        public async Task<FormVM> GetASingleFormDetails(Guid id)
        {
            var getASingleForm = await _client.FormsGETAsync(id);
            return _mapper.Map<FormVM>(getASingleForm);
        }

        public async Task<string> TrackForm(int formId)
        {
            var response = await _client.TrackFormStatusAsync(formId);

            if (response.Exists)
            {
                
                return response.Status;
            }

            // Handle error response or throw an exception
            throw new Exception("Failed to retrieve form status.");
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
