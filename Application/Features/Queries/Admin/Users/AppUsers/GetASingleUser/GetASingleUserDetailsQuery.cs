using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;

public record class GetASingleUserDetailsQuery(string Id) : IRequest<GetASingleUserDTO>;
