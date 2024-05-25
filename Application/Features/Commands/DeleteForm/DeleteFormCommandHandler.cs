using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteForm
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, Unit>
    {
        private readonly IFormRepository _formRepository;

        public DeleteFormCommandHandler(IMapper mapper, IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Unit> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var formToDelete = await _formRepository.GetByIdAsync(request.Id);

            //Verify if the record exist

            //remove the record from the database 
            await _formRepository.DeleteAsync(formToDelete);

            //Return result.
            return Unit.Value;
        }
    }
}
