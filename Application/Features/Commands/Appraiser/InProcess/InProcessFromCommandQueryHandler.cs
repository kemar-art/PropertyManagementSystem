using Application.Contracts.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.InProcess
{
    public class InProcessFromCommandQueryHandler : IRequestHandler<InProcessFromCommandQuery, Unit>
    {
        private readonly IAppraiserRerpository _appraiserRerpository;

        public InProcessFromCommandQueryHandler(IAppraiserRerpository appraiserRerpository)
        {
            _appraiserRerpository = appraiserRerpository;
        }

        public async Task<Unit> Handle(InProcessFromCommandQuery request, CancellationToken cancellationToken)
        {
            var markFormAsInProcess = await _appraiserRerpository.MarkTheFormAsInProcessThatWasAssigned(request.FormId);
            return markFormAsInProcess;
        }
    }
}
