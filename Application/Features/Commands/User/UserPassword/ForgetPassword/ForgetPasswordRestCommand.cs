using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ForgetPassword
{
    public class ForgetPasswordRestCommand : IRequest<AppResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}
