using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers;

internal class ClientUserCommandHandler : IRequestHandler<ClientUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ClientUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(ClientUserCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new ClientUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("An error was encountered when creating the user.", validationResult);
        }

        // Convert incoming entity to domain entity
        //var userToCreate = _mapper.Map<ApplicationUser>(request);

        // Add to database 
        var userToCreate = await _userRepository.RegisterClientUserAsync(request);

        // Return result
        return userToCreate;
    }
}
