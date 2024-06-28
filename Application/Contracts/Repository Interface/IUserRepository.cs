using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Application.Contracts.Repository_Interface
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<string> CreateAppUserAsync(CreateAppUserCommand user, IFormFile image);
        

        Task<Unit> UpdateAppUserAsync(UpdateAppUserCommand user, IFormFile image);
        
    }
}
