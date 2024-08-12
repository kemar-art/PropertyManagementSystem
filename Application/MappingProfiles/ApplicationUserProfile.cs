using Application.Features.Commands.User.ClientUsers.Update;
using Application.Features.Queries.Admin.Users.AppUsers.GetAllUsers;
using Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;
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
            CreateMap<ApplicationUser, GetAllUsersDTO>().ReverseMap();
            CreateMap<ApplicationUser, GetASingleUserDTO>().ReverseMap();

            //CreateMap<ClientUpdateCommand, ApplicationUser>().ReverseMap();
        }
    }
}
