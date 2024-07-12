using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PMS.UI.AuthProviders;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation.AuthService
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> IsAuthenticated(string email, string password)
        {
            try
            {
                LoginUserCommand loginUserCommand = new()
                {
                    Email = email,
                    Password = password
                };

                var authenticationResponse = await _client.LoginAsync(loginUserCommand);
                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).loggedIn();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> IsRegister(string firstName, string lastName, string email, string gender, DateTime dateOfBirth, string password)
        {
            ClientRegistrationCommand registrationRequest = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Password = password
            };

            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).loggedOut();
        }
    }
}
