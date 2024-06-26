﻿using Application.Exceptions;
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

namespace Application.Features.Commands.User.AppUsers.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("An error was encountered when creating the user.", validationResult);
        }

        // Convert incoming entity to domain entity
        //var userToCreate = _mapper.Map<ApplicationUser>(request);

        // Add to database 
        var userToCreate = await _userRepository.RegisterAppUserAsync(request);

        // Return result
        return userToCreate.Id;
    }

}
