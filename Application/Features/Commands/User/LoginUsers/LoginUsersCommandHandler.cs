using Application.AuthSettings;
using Application.Contracts.Identity;
using Domain;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.LoginUsers
{
    public class LoginUsersCommandHandler : IRequestHandler<LoginUserCommand, BaseResult<AuthResponse>>
    {
        private readonly IAuthService _authService;

        public LoginUsersCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<BaseResult<AuthResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Attempt to log in the user using the authentication service
            var userLoggingIn = await _authService.LogInUserAsync(request);

            // Check if the login was successful
            if (!userLoggingIn.IsSuccess)
            {
                // Return the failure result as it is
                return BaseResult<AuthResponse>.Failure(userLoggingIn.Error);
            }

            // Return the successful result
            return BaseResult<AuthResponse>.Success(userLoggingIn.Value);
        }

    }
}
