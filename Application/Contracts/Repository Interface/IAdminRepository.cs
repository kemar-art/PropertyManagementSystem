using Application.Features.Commands.Admin.AssignForm;
using Application.Features.Commands.User.BackOfficeUsers.CreateUser;
using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Domain;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Application.Contracts.Repository_Interface
{
    public interface IAdminRepository : IGenericRepository<ApplicationUser>
    {
        Task<BaseResult<AppResponse>> RegisterAdminUserAsync(CreateBackOfficeUserCommand user, string imagePath);
        Task<Unit> UpdateAppUserAsync(UpdateBackOfficeUserCommand user, IFormFile image);
        Task<IEnumerable<Form>> GetFormByStatusForAdmin(string status);
        Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser);
        Task<Unit> MarkFormHasComplete(Guid? formId, string? appraiserId);
        Task<Unit> ReturnTheFormToAppraiserForCompletion(Guid? returnFormToAppraiser);
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
