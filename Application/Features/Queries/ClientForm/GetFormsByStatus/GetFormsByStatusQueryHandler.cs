using Application.Contracts.ILogging;
using Application.Contracts.Repository_Interface;
using Application.StaticDetails;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.ClientForm.GetFormsByStatus
{
    public class GetFormsByStatusQueryHandler : IRequestHandler<GetFormsByStatusQuery, IEnumerable<Form>>
    {
        private readonly IAppLogger<GetFormsByStatusQueryHandler> _appLogger;
        private readonly IAdminRepository _adminRepository;

        public GetFormsByStatusQueryHandler(IAppLogger<GetFormsByStatusQueryHandler> appLogger, IAdminRepository adminRepository)
        {
            _appLogger = appLogger;
            _adminRepository = adminRepository;;
        }

        public async Task<IEnumerable<Form>> Handle(GetFormsByStatusQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Form> getFormByStatus = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                getFormByStatus = await _adminRepository.GetFormByStatusForAdmin(request.Status);
            }
            else
            {
                getFormByStatus = await _adminRepository.GetFormByStatusForAdmin(FormStatus.StatusSubmitted);
            }

            return getFormByStatus;
        }
    }
}
