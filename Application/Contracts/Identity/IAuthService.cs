using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Application.IdentityModels;
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
        Task<RegistrationResponse> RegisterClientUserAsync(ClientUserCommand user);
        Task<AuthResponse> LogInUserAsync(LoginUserCommand user);
    }
}
