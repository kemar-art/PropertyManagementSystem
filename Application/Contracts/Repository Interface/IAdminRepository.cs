using Application.Features.Commands.Admin.AssignForm;
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
    public interface IAdminRepository : IGenericRepository<ApplicationUser>
    {
        Task<string> RegisterAppUserAsync(CreateAppUserCommand user, IFormFile image);
        Task<Unit> UpdateAppUserAsync(UpdateAppUserCommand user, IFormFile image);
        Task<IEnumerable<Form>> GetFormByStatusForAdmin(string status);
        Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser);
    }
}
