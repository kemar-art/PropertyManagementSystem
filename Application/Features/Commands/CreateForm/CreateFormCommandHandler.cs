using Application.Features.Queries.GetASingleForm;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateForm
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;

        public CreateFormCommandHandler(IMapper mapper, IFormRepository formRepository) 
        {
            _mapper = mapper;
            _formRepository = formRepository;
        }

        public async Task<int> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Convert incoming entity to domain entity
            var formToCreate = _mapper.Map<Form>(request);
            //Add to database 
            await _formRepository.CreateAsync(formToCreate);

            //Return result.
            return formToCreate.Id;
        }
    }
}
