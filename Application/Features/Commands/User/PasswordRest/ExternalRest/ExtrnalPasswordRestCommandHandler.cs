using Application.Contracts.Identity;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.PasswordRest.ExternalRest
{
    public class ExtrnalPasswordRestCommandHandler : IRequestHandler<ExtrnalPasswordRestCommand, AppResponse>
    {
        private readonly IAuthService _authService;

        public ExtrnalPasswordRestCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AppResponse> Handle(ExtrnalPasswordRestCommand request, CancellationToken cancellationToken)
        {
            var findUserByEmail = await _authService.ExternalPasswordReset(request.Email);
            return findUserByEmail;
        }
    }
}
