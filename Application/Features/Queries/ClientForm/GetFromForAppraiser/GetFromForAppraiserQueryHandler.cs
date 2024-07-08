using Application.Contracts.Repository_Interface;
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
        private readonly IAppraiserRerpository _appraiserRerpository;

        public GetFromForAppraiserQueryHandler(IAppraiserRerpository appraiserRerpository)
        {
            _appraiserRerpository = appraiserRerpository;
        }

        public async Task<IEnumerable<Form>> Handle(GetFromForAppraiserQuery request, CancellationToken cancellationToken)
        {
            var getFromForAppraiser = await _appraiserRerpository.GetFormThatWasAssignedToAppraiser();
            return getFromForAppraiser;
        }
    }
}

