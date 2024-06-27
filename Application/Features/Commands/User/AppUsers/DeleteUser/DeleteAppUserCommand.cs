using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.AppUsers.DeleteUser
{
    public class DeleteAppUserCommand : IRequest<Unit>
    {
        public string Id { get; set; } = string.Empty;
    }
}
