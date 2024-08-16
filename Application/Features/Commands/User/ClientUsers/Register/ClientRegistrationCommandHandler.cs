using Application.AuthSettings;
using Application.Contracts.Identity;
using Application.Contracts.ILogging;
using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Common;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers.Register;

public class ClientRegistrationCommandHandler : IRequestHandler<ClientRegistrationCommand, BaseResult<RegistrationResponse>>
{
    private readonly IAuthService _authService;
    private readonly IAppLogger<ClientRegistrationCommandHandler> _appLogger;

    public ClientRegistrationCommandHandler(IAuthService authService, IAppLogger<ClientRegistrationCommandHandler> appLogger)
    {
        _authService = authService;
        _appLogger = appLogger;
    }

    public async Task<BaseResult<RegistrationResponse>> Handle(ClientRegistrationCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new ClientRegistrationCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            var errorMessage = "An error was encountered when creating the user.";
            // Return validation errors as a failure result
            return BaseResult<RegistrationResponse>.Failure($"{errorMessage} {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}");
        }

        // Check if the email already exists
        var emailExists = await _authService.IsEmailRegisteredExist(request.Email);
        if (!emailExists.IsSuccess)
        {
            // Return email already in use error as a failure result
            return BaseResult<RegistrationResponse>.Failure("Email already in use.");
        }

        try
        {
            // Register the user
            var registrationResult = await _authService.RegisterClientUserAsync(request);

            if (!registrationResult.IsSuccess)
            {
                // Return the registration failure result
                return BaseResult<RegistrationResponse>.Failure(registrationResult.Error);
            }

            // Return the successful registration result
            return BaseResult<RegistrationResponse>.Success(registrationResult.Value);
        }
        catch (Exception ex)
        {
            // Log the unexpected error
            _appLogger.LogError("An unexpected error occurred while handling user registration.", ex);

            // Return a generic failure result
            return BaseResult<RegistrationResponse>.Failure("An unexpected error occurred. Please try again later.");
        }
    }

}
