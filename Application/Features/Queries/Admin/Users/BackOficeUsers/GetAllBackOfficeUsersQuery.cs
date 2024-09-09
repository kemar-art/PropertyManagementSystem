using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.BackOficeUsers;

public record class GetAllBackOfficeUsersQuery : IRequest<IEnumerable<GetAllBackOfficeUsersDTO>>;
