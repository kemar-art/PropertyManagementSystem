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
        Task<BaseResult<RegistrationResponse>> RegisterClientUserAsync(ClientRegistrationCommand user);
        Task<BaseResult<AuthResponse>> LogInUserAsync(LoginUserCommand user);
        Task<BaseResult<bool>> IsEmailRegisteredExist(string email);
        Task<CustomResponse> ForgetPassword(string email);
        Task<CustomResponse> AdminForgetPassword(string email);
        Task<CustomResponse> NoneLoginResetPassword(NoneLoginUserPasswordResetCommand resetPassword);
        Task<CustomResponse> LoginUserPasswordReset(LoginUserPasswordResetCommand resetPassword);
    }
}
