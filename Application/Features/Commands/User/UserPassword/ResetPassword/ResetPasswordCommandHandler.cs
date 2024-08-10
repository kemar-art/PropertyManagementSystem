using Application.Contracts.Identity;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, AppResponse>
    {
        private readonly IAuthService _authService;

        public ResetPasswordCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AppResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var response = await _authService.PasswordReset(request);
            return response;
        }
    }
}
