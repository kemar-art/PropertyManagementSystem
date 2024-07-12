using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PMS.UI.AuthProviders
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var isTokenPresent = await _localStorage.ContainKeyAsync("token");
            if (isTokenPresent == false)
            {
                return new AuthenticationState(user);
            }

            var savedToken = await _localStorage.GetItemAsync<string>("token");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            if (tokenContent.ValidTo < DateTime.Now)
            {
                await _localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);

        }

        public async Task loggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new  ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task loggedOut()
        {
            await _localStorage.RemoveItemAsync("token");
            var noBody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(noBody));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var saveToken = await _localStorage.GetItemAsync<string>("token");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(saveToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
