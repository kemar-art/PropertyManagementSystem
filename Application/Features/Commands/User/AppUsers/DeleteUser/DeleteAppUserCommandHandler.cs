using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.ClientForm.DeleteForm;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.AppUsers.DeleteUser
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteAppUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            //Find the form to be deleted
            var userToDelete = await _userRepository.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (userToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteFormCommand), request.Id);
            }

            //remove the record from the database 
            await _userRepository.DeleteAsync(userToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
