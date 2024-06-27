﻿using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Domain;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Contracts.Repository_Interface
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<string> RegisterAppUserAsync(CreateAppUserCommand user);
        Task<string> RegisterClientUserAsync(ClientUserCommand user);

        Task<Unit> UpdateAppUserAsync(UpdateAppUserCommand user);
        Task<Unit> LogInUserAsync(LoginUsersCommand user);
    }
}
