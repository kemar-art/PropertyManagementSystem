﻿using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.BackOfficeUsers.DeleteUser
{
    public class DeleteAppUserCommand : IRequest<CustomResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
