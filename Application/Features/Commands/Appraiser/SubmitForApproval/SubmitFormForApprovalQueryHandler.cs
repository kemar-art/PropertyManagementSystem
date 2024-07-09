using Application.Contracts.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.SubmitForApproval
{
    public class SubmitFormForApprovalQueryHandler : IRequestHandler<SubmitFormForApprovalQuery, Unit>
    {
        private readonly IAppraiserRerpository _appraiserRerpository;

        public SubmitFormForApprovalQueryHandler(IAppraiserRerpository appraiserRerpository)
        {
            _appraiserRerpository = appraiserRerpository;
        }

        public async Task<Unit> Handle(SubmitFormForApprovalQuery request, CancellationToken cancellationToken)
        {
            var markFormAsInProcess = await _appraiserRerpository.SubmitFormForApprovalThatWasAssigned(request.FormId, request.FrontOfProperyImage, request.LeftSideOfPropertImage, request.RightSideOfPropertyImage, request.BackOfPropertyImage);
            return markFormAsInProcess;
        }
    }
}
