using Application.Contracts.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.AcceptForm
{
    public class AcceptFromCommandQueryHandler : IRequestHandler<AcceptFromCommandQuery, Unit>
    {
        private readonly IAppraiserRerpository _appraiserRerpository;

        public AcceptFromCommandQueryHandler(IAppraiserRerpository appraiserRerpository)
        {
            _appraiserRerpository = appraiserRerpository;
        }

        public async Task<Unit> Handle(AcceptFromCommandQuery request, CancellationToken cancellationToken)
        {
            var acceptForm = await _appraiserRerpository.AcceptTheFormThatWasAssigned(request.FormId);
            return acceptForm;
        }
    }
}
