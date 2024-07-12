using Application.AuthSettings;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
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
    }
}
