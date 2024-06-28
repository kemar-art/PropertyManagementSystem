using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IAuthService
    {
        Task<Unit> RegisterClientUserAsync(ClientUserCommand user);
        Task<Unit> LogInUserAsync(LoginUsersCommand user);
    }
}
