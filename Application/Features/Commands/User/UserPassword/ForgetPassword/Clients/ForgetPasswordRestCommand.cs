﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UserPassword.ForgetPassword.Clients
{
    public class ForgetPasswordRestCommand : IRequest<CustomResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}
