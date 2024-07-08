using Application.Contracts.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.RejectForm
{
    public class RejectFromCommandQueryHandler : IRequestHandler<CommonFromCommand, Unit>
    {
        private readonly IAppraiserRerpository _appraiserRerpository;

        public RejectFromCommandQueryHandler(IAppraiserRerpository appraiserRerpository)
        {
            _appraiserRerpository = appraiserRerpository;
        }

        public Task<Unit> Handle(CommonFromCommand request, CancellationToken cancellationToken)
        {
            var rejectForm = _appraiserRerpository.RejectTheFormThatWasAssigned(request);
            return rejectForm;
        }
    }
}
