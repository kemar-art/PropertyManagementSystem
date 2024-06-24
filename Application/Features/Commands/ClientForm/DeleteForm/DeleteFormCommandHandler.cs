using Application.Exceptions;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Commands.ClientForm.DeleteForm
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, Unit>
    {
        private readonly IFormRepository _formRepository;

        public DeleteFormCommandHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Unit> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var formToDelete = await _formRepository.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (formToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteFormCommand), request.Id);
            }

            //remove the record from the database 
            await _formRepository.DeleteAsync(formToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
