using Application.Features.Commands.User.CreateUser;
using Application.Features.Commands.User.UpdateUser;
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
        Task RegisterAsync(ApplicationUser user);
        Task<Unit> UpdateUserAsync(UpdateUserCommand user);
    }
}
