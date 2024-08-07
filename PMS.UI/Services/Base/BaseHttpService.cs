using Blazored.LocalStorage;
using Blazored.SessionStorage;
using PMS.UI.StaticDetails;
using System.Net.Http.Headers;

namespace PMS.UI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;
        protected readonly ISessionStorageService _sessionStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage)
        {
            _client = client;
            _localStorage = localStorage;
            _sessionStorage = sessionStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The record was not found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync(AuthToken.Token))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>(AuthToken.Token));
        }

    }
}
