using Application.Exceptions;
using Application.Features.Commands.ClientForm.CreateForm;
using Domain.Repository_Interface;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Contracts.Repository_Interface;
using FluentValidation;
using System.ComponentModel;
using System.Reflection;
using System.Security.AccessControl;
using Domain.Common;
using Application.Contracts.ILogging;
using Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.User.BackOfficeUsers.CreateUser;

public class CreateBackOfficeUserCommandHandler : IRequestHandler<CreateBackOfficeUserCommand, BaseResult<AppResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAdminRepository _userRepository;
    private readonly IAppLogger<CreateBackOfficeUserCommandHandler> _appLogger;
    private readonly IAuthService _authService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateBackOfficeUserCommandHandler(IMapper mapper, IAdminRepository userRepository, IAppLogger<CreateBackOfficeUserCommandHandler> appLogger, IAuthService authService, UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _appLogger = appLogger;
        _authService = authService;
        _userManager = userManager;
    }

    public async Task<BaseResult<AppResponse>> Handle(CreateBackOfficeUserCommand request, CancellationToken cancellationToken)
    {
        // Check for null request
        if (request == null)
        {
            _appLogger.LogError("CreateBackOfficeUserCommand request is null.");
            return BaseResult<AppResponse>.Failure("Request cannot be null.");
        }

        // Validate incoming data
        var validator = new CreateBackOfficeUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            _appLogger.LogWarning("Validation failed for CreateBackOfficeUserCommand: {Errors}", validationResult.Errors);
            return BaseResult<AppResponse>.Failure("An error was encountered when creating the user.");
        }

        // Check if the email already exists
        var emailExists = await _userManager.FindByEmailAsync(request.Email);
        if (emailExists != null)
        {
            _appLogger.LogWarning("Attempt to create a user with an email that is already in use: {Email}", request.Email);
            return BaseResult<AppResponse>.Failure("Email already in use.");
        }

        try
        {
            // Add to database
            var userToCreate = await _userRepository.RegisterAdminUserAsync(request, request.ImagePath);
            _appLogger.LogInformation("User successfully created with email: {Email}", request.Email);

            // Return success result
            return userToCreate;
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An error occurred while creating the user: {Email}", request.Email, ex);
            return BaseResult<AppResponse>.Failure("An error occurred while processing your request.");
        }
    }


}
