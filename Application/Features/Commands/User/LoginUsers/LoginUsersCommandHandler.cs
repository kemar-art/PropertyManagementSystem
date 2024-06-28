using Application.Identity;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.LoginUsers
{
    public class LoginUsersCommandHandler : IRequestHandler<LoginUsersCommand, Unit>
    {
        private readonly IAuthService _authService;

        public LoginUsersCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Unit> Handle(LoginUsersCommand request, CancellationToken cancellationToken)
        {
            var userToCreate = await _authService.LogInUserAsync(request);

            // Return result
            return userToCreate;
        }
    }
}
