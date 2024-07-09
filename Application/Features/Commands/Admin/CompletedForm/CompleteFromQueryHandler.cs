using Application.Contracts.Repository_Interface;
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
        private readonly IAdminRepository _adminRepository;

        public CompleteFromQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Unit> Handle(CompleteFromQuery request, CancellationToken cancellationToken)
        {
            var assignForm = await _adminRepository.MarkFormHasComplete(request.FormId, request.AppraiserId);
            return assignForm;
        }
    }
}
