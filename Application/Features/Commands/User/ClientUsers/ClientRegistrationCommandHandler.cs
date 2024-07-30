using Application.AuthSettings;
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

public class ClientRegistrationCommandHandler : IRequestHandler<ClientRegistrationCommand, RegistrationResponse>
{
    private readonly IAuthService _authService;

    public ClientRegistrationCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegistrationResponse> Handle(ClientRegistrationCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new ClientRegistrationCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("An error was encountered when creating the user.", validationResult);
        }

        var emailExists = await _authService.IsEmailRegisteredExist(request.Email);
        if (emailExists)
        {
            throw new BadRequestException("Email already in use.");
        }

        // Add to database 
        var userToCreate = await _authService.RegisterClientUserAsync(request);

        // Return result
        return userToCreate;
    }
}
