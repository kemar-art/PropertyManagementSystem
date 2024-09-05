using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.ClientForm.GetFormCount
{
    public class GetFormCountQueryHandler : IRequestHandler<GetFormCountQuery, int>
    {
        private readonly IFormRepository _formRepository;

        public GetFormCountQueryHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<int> Handle(GetFormCountQuery request, CancellationToken cancellationToken)
        {
            var getFormCount = await _formRepository.GetFormCount(request.status);
            return getFormCount;
        }
    }
}
