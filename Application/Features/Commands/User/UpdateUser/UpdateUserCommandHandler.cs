using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.ClientForm.UpdateForm;
using AutoMapper;
using Domain.Repository_Interface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateUserCommandValidation(_userRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting form for update", validationResult);
            }

            //Convert incoming entity to domain entity
            //var userToUpdate = _mapper.Map<ApplicationUser>(request);

            //Add to database 
            await _userRepository.UpdateUserAsync(request);

            //Return result.
            return Unit.Value;
        }
    }
}
