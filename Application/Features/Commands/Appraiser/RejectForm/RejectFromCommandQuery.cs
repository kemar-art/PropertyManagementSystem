using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.RejectForm
{
    public class RejectFromCommandQuery : CommonFromCommand, IRequest<Unit>
    {
    }
}
