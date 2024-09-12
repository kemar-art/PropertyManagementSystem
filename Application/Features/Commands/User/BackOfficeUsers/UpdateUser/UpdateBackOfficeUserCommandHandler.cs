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
using Domain.Common;

namespace Application.Features.Commands.User.BackOfficeUsers.UpdateUser
{
    public class UpdateBackOfficeUserCommandHandler : IRequestHandler<UpdateBackOfficeUserCommand, BaseResult<CustomResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _userRepository;

        public UpdateBackOfficeUserCommandHandler(IMapper mapper, IAdminRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseResult<CustomResponse>> Handle(UpdateBackOfficeUserCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateBackOfficeUserCommandValidation(_userRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting form for update", validationResult);
            }

            //Convert incoming entity to domain entity
            //var userToUpdate = _mapper.Map<ApplicationUser>(request);

            //Add to database 
            var updatedUser = await _userRepository.UpdateAppUserAsync(request, request.ImagePath);

            //Return result.
            return updatedUser;
        }
    }
}
