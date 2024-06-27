﻿using Application.Contracts.Repository_Interface;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.LoginUsers
{
    public class LoginUsersCommandHandler : IRequestHandler<LoginUsersCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public LoginUsersCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(LoginUsersCommand request, CancellationToken cancellationToken)
        {
            var userToCreate = await _userRepository.LogInUserAsync(request);

            // Return result
            return userToCreate;
        }
    }
}
