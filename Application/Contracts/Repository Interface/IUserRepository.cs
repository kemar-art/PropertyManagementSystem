using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository_Interface
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<string> RegisterAppUserAsync(CreateAppUserCommand user);
        Task<string> RegisterClientUserAsync(ClientUserCommand user);

        Task<Unit> UpdateAppUserAsync(UpdateAppUserCommand user);
    }
}
