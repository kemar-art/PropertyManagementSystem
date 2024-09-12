using Application.Features.Commands.Admin.AssignForm;
using Application.Features.Commands.User.BackOfficeUsers.CreateUser;
using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Queries.Admin.Users.BackOficeUsers;
using Application.Features.Queries.Admin.Users.ClientUsers;
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
        Task<BaseResult<CustomResponse>> RegisterAdminUserAsync(CreateBackOfficeUserCommand user, string imagePath);
        Task<BaseResult<CustomResponse>> UpdateBackOfficeUserAsync(UpdateBackOfficeUserCommand user, string imagePath);
        Task<IEnumerable<Form>> GetFormByStatusForAdmin(string status);
        Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser);
        Task<Unit> MarkFormHasComplete(Guid? formId, string? appraiserId);
        Task<Unit> ReturnTheFormToAppraiserForCompletion(Guid? returnFormToAppraiser);
        Task<IEnumerable<IdentityRole>> GetRoles();

        Task<IEnumerable<GetAllBackOfficeUsersDTO>> GetAllBackOfficeUsers();
        Task<IEnumerable<GetAllClientUsersDTO>> GetAllClientUsers();

        Task<CustomResponse> DeleteAllUsers(string userId);
    }
}
