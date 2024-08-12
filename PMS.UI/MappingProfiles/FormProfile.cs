using AutoMapper;
using PMS.UI.Models.Client;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;


namespace Application.MappingProfiles;

public class FormProfile : Profile
{
    public FormProfile()
    {
        CreateMap<GetASingleUserDTO, ClientVM>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.DateTime))
            .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => src.Image))
            .ReverseMap();

        // Other mappings
        CreateMap<FormVM, GetAllFormsDto>().ReverseMap();
        CreateMap<FormVM, GetFormDetailsDto>().ReverseMap();
        CreateMap<CreateFormCommand, FormVM>().ReverseMap();
        CreateMap<GetASingleUserDTO, FormVM>().ReverseMap();
    }
}

