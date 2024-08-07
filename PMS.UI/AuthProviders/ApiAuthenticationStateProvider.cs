using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PMS.UI.StaticDetails;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PMS.UI.AuthProviders
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ISessionStorageService _sessionStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage, ISessionStorageService sessionStorage)
        {
            _localStorage = localStorage;
            _sessionStorage = sessionStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var tokenKey = AuthToken.Token;

            // Check local storage first
            if (await _localStorage.ContainKeyAsync(tokenKey))
            {
                var savedToken = await _localStorage.GetItemAsync<string>(tokenKey);
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);

                if (tokenContent.ValidTo >= DateTime.Now)
                {
                    var claims = await GetClaims(savedToken);
                    user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
                    return new AuthenticationState(user);
                }
                else
                {
                    await _localStorage.RemoveItemAsync(tokenKey);
                }
            }

            // Check session storage if not found in local storage
            if (await _sessionStorage.ContainKeyAsync(tokenKey))
            {
                var savedToken = await _sessionStorage.GetItemAsync<string>(tokenKey);
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);

                if (tokenContent.ValidTo >= DateTime.Now)
                {
                    var claims = await GetClaims(savedToken);
                    user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
                    return new AuthenticationState(user);
                }
                else
                {
                    await _sessionStorage.RemoveItemAsync(tokenKey);
                }
            }

            return new AuthenticationState(user);
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims(await GetToken());
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            // Remove token from local storage if present
            if (await _localStorage.ContainKeyAsync(AuthToken.Token))
            {
                await _localStorage.RemoveItemAsync(AuthToken.Token, cancellationToken: default);
            }

            // Remove token from session storage if present
            if (await _sessionStorage.ContainKeyAsync(AuthToken.Token))
            {
                await _sessionStorage.RemoveItemAsync(AuthToken.Token, cancellationToken: default);
            }

            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<List<Claim>> GetClaims(string token)
        {
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(token);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        private async Task<string> GetToken()
        {
            var tokenKey = AuthToken.Token;
            if (await _localStorage.ContainKeyAsync(tokenKey))
            {
                return await _localStorage.GetItemAsync<string>(tokenKey);
            }

            if (await _sessionStorage.ContainKeyAsync(tokenKey))
            {
                return await _sessionStorage.GetItemAsync<string>(tokenKey);
            }

            return null;
        }
    }
}
