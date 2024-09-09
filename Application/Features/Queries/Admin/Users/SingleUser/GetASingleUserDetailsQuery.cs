using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.SingleUser;

public record class GetASingleUserDetailsQuery(string userId) : IRequest<GetASingleUserDTO>;
