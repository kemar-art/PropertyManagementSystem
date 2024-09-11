using Application.Contracts.Identity;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset
{
    public class LoginUserPasswordResetCommandHandler : IRequestHandler<NoneLoginUserPasswordResetCommand, CustomResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserPasswordResetCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CustomResponse> Handle(NoneLoginUserPasswordResetCommand request, CancellationToken cancellationToken)
        {

            var response = await _authService.NoneLoginResetPassword(request);


            return response;
        }
    }
}
