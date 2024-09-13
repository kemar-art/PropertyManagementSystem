using AutoMapper;
using PMS.UI.Models.Client;
using PMS.UI.Models.Employee;
using PMS.UI.Services.Base;


namespace Application.MappingProfiles;

public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<GetAllBackOfficeUsersDTO, ApplicationUserVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date))
            .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.Date))
            .ForMember(dest => dest.DateEnded, opt => opt.MapFrom(src => src.DateEnded.Date))
            .ReverseMap();

        CreateMap<GetAllClientUsersDTO, ClientVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date))
            //.ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.Date))
            .ReverseMap();
        //CreateMap<ApplicationUserVM, GetFormDetailsDto>().ReverseMap();

        CreateMap<GetASingleUserDTO, ClientVM>()
           .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
           //.ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
           .ReverseMap();


        CreateMap<ClientUpdateCommand, ClientVM>()
           .ReverseMap();

        CreateMap<UpdateBackOfficeUserCommand, ApplicationUserVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
            .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.DateTime))
            .ForMember(dest => dest.DateEnded, opt => opt.MapFrom(src => src.DateEnded.DateTime))
           .ReverseMap();

        CreateMap<CreateBackOfficeUserCommand, ApplicationUserVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
            .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.DateTime))
            .ForMember(dest => dest.DateEnded, opt => opt.MapFrom(src => src.DateEnded.DateTime))
           .ReverseMap();


        CreateMap<GetASingleUserDTO, ApplicationUserVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
            .ForMember(dest => dest.DateRegistered, opt => opt.MapFrom(src => src.DateRegistered.DateTime))
            .ForMember(dest => dest.DateEnded, opt => opt.MapFrom(src => src.DateEnded.DateTime))
            .ReverseMap();
    }
}
