using Application.Contracts.ILogging;
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
        private readonly IFormRepository _formRepository;

        public GetFormsByStatusQueryHandler(IAppLogger<GetFormsByStatusQueryHandler> appLogger, IFormRepository formRepository)
        {
            _appLogger = appLogger;
            _formRepository = formRepository;
        }

        public async Task<IEnumerable<Form>> Handle(GetFormsByStatusQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Form> getFormByStatus = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                getFormByStatus = await _formRepository.GetFormByStatus(request.Status);
            }
            else
            {
                getFormByStatus = await _formRepository.GetFormByStatus(FormStatus.StatusSubmitted);
            }

            return getFormByStatus;
        }
    }
}
