using Application.Contracts.Identity;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ForgetPassword.Admins
{
    public class AdminForgetPasswordRestCommandHandler : IRequestHandler<AdminForgetPasswordRestCommand, CustomResponse>
    {
        private readonly IAuthService _authService;

        public AdminForgetPasswordRestCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CustomResponse> Handle(AdminForgetPasswordRestCommand request, CancellationToken cancellationToken)
        {
            var findUserByEmail = await _authService.AdminForgetPassword(request.Email);
            return findUserByEmail;
        }
    }
}
