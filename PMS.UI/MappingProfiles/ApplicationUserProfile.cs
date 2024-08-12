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

        CreateMap<ClientVM, GetASingleUserDTO>().ReverseMap();
        CreateMap<ClientVM, UpdateAppUserCommand>().ReverseMap();
    }
}
