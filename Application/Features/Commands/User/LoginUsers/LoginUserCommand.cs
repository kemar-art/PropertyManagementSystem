using Application.AuthSettings;
using Domain.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.LoginUsers
{
    public class LoginUserCommand : IRequest<BaseResult<AuthResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //public bool RememberMe { get; set; }
    }
}