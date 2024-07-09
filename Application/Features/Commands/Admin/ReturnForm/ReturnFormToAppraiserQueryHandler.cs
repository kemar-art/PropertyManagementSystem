using Application.Contracts.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin.ReturnForm
{
    public class ReturnFormToAppraiserQueryHandler : IRequestHandler<ReturnFormToAppraiserQuery, Unit>
    {
        private readonly IAdminRepository _adminRepository;

        public ReturnFormToAppraiserQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Unit> Handle(ReturnFormToAppraiserQuery request, CancellationToken cancellationToken)
        {
            var returnFormToAppraiser = await _adminRepository.ReturnTheFormToAppraiserForCompletion(request.FormId);
            return returnFormToAppraiser;
        }
    }
}
