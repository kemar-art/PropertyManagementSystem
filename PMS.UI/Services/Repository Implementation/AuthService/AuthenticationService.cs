using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PMS.UI.AuthProviders;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using PMS.UI.Models.Client;
using PMS.UI.Services.Base;
using PMS.UI.StaticDetails;

namespace PMS.UI.Services.Repository_Implementation.AuthService
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, ISessionStorageService sessionStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage, sessionStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<AppResponse> ForgetPassword(ForgetPassword passwordResetVM)
        {
            ForgetPasswordRestCommand extrnalPasswordRest = new()
            {
                Email = passwordResetVM.Email,
            };

            var response = await _client.ForgetpasswordAsync(extrnalPasswordRest);
            if (response.IsSuccess)
            {
                return response;
            }

            return response;
        }

        public async Task<LoginResponse> IsAuthenticated(LoginVM loginVM)
        {
            try
            {
                LoginUserCommand loginUserCommand = new()
                {
                    Email = loginVM.Email,
                    Password = loginVM.Password,
                };

                var authenticationResponse = await _client.LoginAsync(loginUserCommand);

                if (!string.IsNullOrEmpty(authenticationResponse.Token))
                {
                    if (loginVM.RememberMe)
                    {
                        // Store token in local storage and clear it from session storage
                        await _localStorage.SetItemAsync(AuthToken.Token, authenticationResponse.Token);
                        //await _sessionStorage.RemoveItemAsync(AuthToken.Token);
                    }
                    else
                    {
                        // Store token in session storage and clear it from local storage
                        await _sessionStorage.SetItemAsync(AuthToken.Token, authenticationResponse.Token);
                    }

                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                    return new LoginResponse { IsAuthenticate = true, Role = authenticationResponse.Role};
                }

                return new LoginResponse { IsAuthenticate = false};
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Exception: {ex.Message}");
                return new LoginResponse { IsAuthenticate = false };
            }
        }




        public async Task<bool> IsEmailRegisteredExist(string email)
        {
            return await _client.EmailcheckAsync(email);
        }

        public async Task<bool> IsRegister(RegisterVM registerVM)
        {
            ClientRegistrationCommand registrationRequest = new()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                Address = registerVM.Address,
                PhoneNumber = registerVM.PhoneNumber,
                Gender = registerVM.Gender,
                DateOfBirth = registerVM.DateOfBirth,
                Password = registerVM.Password,
                ClientRegionId = registerVM.ClientRegionId,
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
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<AppResponse> PasswordReset(NoneLoginResetPassword noneLoginUser)
        {
            NoneLoginUserPasswordResetCommand passwordResetCommand = new()
            {
                Id = noneLoginUser.Id,
                Email = noneLoginUser.Email,
                Password = noneLoginUser.NewPassword,
                ResetToken = noneLoginUser.ResetToken
            };

            var response = await _client.ResetpasswordAsync(passwordResetCommand);
            if (response.IsSuccess)
            {
                return response;
            }
            return response;
        }

        public async Task<AppResponse> UpdateResetPassword(LoginUserPasswordReset resetPassword)
        {
            LoginUserPasswordResetCommand passwordResetCommand = new()
            {
                Id = resetPassword.Id,
                CurrentPassword = resetPassword.CurrentPassword,
                NewPassword = resetPassword.NewPassword,
            };

            var response = await _client.UpdatepasswordAsync(passwordResetCommand);
            if (response.IsSuccess)
            {
                return response;
            }
            return response;
        }
    }
}