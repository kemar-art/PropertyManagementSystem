using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset
{
    public class NoneLoginUserPasswordResetCommand : IRequest<AppResponse>
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ResetToken { get; set; } = string.Empty;
    }
}
