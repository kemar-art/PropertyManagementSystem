using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers.Update;
using Application.Features.Queries.Admin.Users.BackOficeUsers;
using Application.Features.Queries.Admin.Users.ClientUsers;
using Application.Features.Queries.Admin.Users.SingleUser;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, GetAllBackOfficeUsersDTO>().ReverseMap();
            CreateMap<ApplicationUser, GetAllClientUsersDTO>().ReverseMap();
            CreateMap<ApplicationUser, GetASingleUserDTO>().ReverseMap();

            CreateMap<ClientUpdateCommand, ApplicationUser>().ReverseMap();
            CreateMap<UpdateBackOfficeUserCommandHandler, ApplicationUser>().ReverseMap();
        }
    }
}
