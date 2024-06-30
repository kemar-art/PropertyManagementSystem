using Domain;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.ClientForm.GetFromForAppraiser
{
    public class GetFromForAppraiserQueryHandler : IRequestHandler<GetFromForAppraiserQuery, IEnumerable<Form>>
    {
        private readonly IFormRepository _formRepository;

        public GetFromForAppraiserQueryHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<IEnumerable<Form>> Handle(GetFromForAppraiserQuery request, CancellationToken cancellationToken)
        {
            var getFromForAppraiser = await _formRepository.GetFormThatWasAssignedToAppraiser();
            return getFromForAppraiser;
        }
    }
}

