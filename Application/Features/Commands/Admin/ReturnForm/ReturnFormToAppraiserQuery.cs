using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin.ReturnForm
{
    public class ReturnFormToAppraiserQuery : CommonFromCommand, IRequest<Unit>
    {
    }
}