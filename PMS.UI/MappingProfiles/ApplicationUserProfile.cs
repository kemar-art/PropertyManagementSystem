using AutoMapper;
using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;


namespace Application.MappingProfiles;

public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<ApplicationUserVM, GetAllUsersDTO>().ReverseMap();
        //CreateMap<ApplicationUserVM, GetFormDetailsDto>().ReverseMap();

        CreateMap<GetASingleUserDTO, ClientVM>()
           .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
           .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
           .ReverseMap();

        CreateMap<ClientUpdateCommand, ClientVM>().ReverseMap();
        CreateMap<ClientVM, UpdateAppUserCommand>().ReverseMap();
    }
}
