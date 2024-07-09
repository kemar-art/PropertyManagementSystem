using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin.CompletedForm
{
    public class CompleteFromQueryHandler : IRequestHandler<CompleteFromQuery, Unit>
    {
        public Task<Unit> Handle(CompleteFromQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
