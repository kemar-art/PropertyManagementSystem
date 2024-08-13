using AutoMapper;
using PMS.UI.Models.Client;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;


namespace Application.MappingProfiles;

public class FormProfile : Profile
{
    public FormProfile()
    {
       

        // Other mappings
        CreateMap<FormVM, GetAllFormsDto>().ReverseMap();
        CreateMap<FormVM, GetFormDetailsDto>().ReverseMap();
        CreateMap<CreateFormCommand, FormVM>().ReverseMap();
        CreateMap<GetASingleUserDTO, FormVM>().ReverseMap();
    }
}

