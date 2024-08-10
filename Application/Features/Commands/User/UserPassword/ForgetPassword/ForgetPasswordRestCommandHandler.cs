using Application.Contracts.Identity;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ForgetPassword
{
    public class ForgetPasswordRestCommandHandler : IRequestHandler<ForgetPasswordRestCommand, AppResponse>
    {
        private readonly IAuthService _authService;

        public ForgetPasswordRestCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AppResponse> Handle(ForgetPasswordRestCommand request, CancellationToken cancellationToken)
        {
            var findUserByEmail = await _authService.ForgetPassword(request.Email);
            return findUserByEmail;
        }
    }
}
