using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin
{
    public class AssignFormToAppraiserCommandHandler : IRequestHandler<AssignFormToAppraiserCommand, Unit>
    {
        private readonly IFormRepository _formRepository;

        public AssignFormToAppraiserCommandHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Unit> Handle(AssignFormToAppraiserCommand request, CancellationToken cancellationToken)
        {
            await _formRepository.AssignJob(request);

            return Unit.Value;
        }
    }
}
