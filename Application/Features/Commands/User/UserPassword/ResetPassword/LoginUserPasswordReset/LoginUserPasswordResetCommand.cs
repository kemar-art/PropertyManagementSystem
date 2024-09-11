using Domain.Common;
using MediatR;

namespace Application.Features.Commands.User.UserPassword.ResetPassword.LoginUserPasswordReset
{
    public class LoginUserPasswordResetCommand : IRequest<CustomResponse>
    {
        public string Id { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}