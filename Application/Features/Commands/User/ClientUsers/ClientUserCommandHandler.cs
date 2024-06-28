using Application.Contracts.Identity;
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

internal class ClientUserCommandHandler : IRequestHandler<ClientUserCommand, RegistrationResponse>
{
    private readonly IAuthService _authService;

    public ClientUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegistrationResponse> Handle(ClientUserCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new ClientUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("An error was encountered when creating the user.", validationResult);
        }

        // Add to database 
        var userToCreate = await _authService.RegisterClientUserAsync(request);

        // Return result
        return userToCreate;
    }
}
