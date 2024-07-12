using Application.AuthSettings;
using Application.Contracts.Identity;
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
    public class LoginUsersCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly IAuthService _authService;

        public LoginUsersCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userLoggingIn = await _authService.LogInUserAsync(request);


            // Return result
            return userLoggingIn;
        }
    }
}
