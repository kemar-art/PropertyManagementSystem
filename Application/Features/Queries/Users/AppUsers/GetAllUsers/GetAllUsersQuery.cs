using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Users.AppUsers.GetAllUsers;

public record class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersDTO>>;
