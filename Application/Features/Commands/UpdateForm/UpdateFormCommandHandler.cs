using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateForm
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;

        public UpdateFormCommandHandler(IMapper mapper, IFormRepository formRepository)
        {
            _mapper = mapper;
            _formRepository = formRepository;
        }

        public async Task<Unit> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Convert incoming entity to domain entity
            var formToUpdate = _mapper.Map<Form>(request);
            //Add to database 
            await _formRepository.UpdateAsync(formToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
