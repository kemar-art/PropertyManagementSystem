using Blazored.LocalStorage;
using Blazored.SessionStorage;
using PMS.UI.StaticDetails;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PMS.UI.Handlers
{
    public class JwtAuthorizationMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ISessionStorageService _sessionStorage;

        public JwtAuthorizationMessageHandler(ILocalStorageService localStorageService, ISessionStorageService sessionStorage)
        {
            _localStorageService = localStorageService;
            _sessionStorage = sessionStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Try to get the token from local storage
            var token = await _localStorageService.GetItemAsync<string>(AuthToken.Token);

            // If token is null or empty, try to get it from session storage
            if (string.IsNullOrEmpty(token))
            {
                token = await _sessionStorage.GetItemAsync<string>(AuthToken.Token);
            }

            // Ensure the token is not null or empty before setting it in the authorization header
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }

    }
}
