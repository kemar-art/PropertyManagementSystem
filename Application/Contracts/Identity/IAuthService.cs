using Application.AuthSettings;
using Application.Features.Commands.User.ClientUsers.Register;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Commands.User.UserPassword.ResetPassword.LoginUserPasswordReset;
using Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<RegistrationResponse> RegisterClientUserAsync(ClientRegistrationCommand user);
        Task<AuthResponse> LogInUserAsync(LoginUserCommand user);
        Task<bool> IsEmailRegisteredExist(string email);
        Task<AppResponse> ForgetPassword(string email);
        Task<AppResponse> NoneLoginResetPassword(NoneLoginUserPasswordResetCommand resetPassword);
        Task<AppResponse> LoginUserPasswordReset(LoginUserPasswordResetCommand resetPassword);
    }
}
