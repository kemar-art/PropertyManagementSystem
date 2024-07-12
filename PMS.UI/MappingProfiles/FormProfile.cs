using AutoMapper;
using PMS.UI.Models.Form;
using PMS.UI.Services.Base;


namespace Application.MappingProfiles;

public class FormProfile : Profile
{
    public FormProfile() 
    {
        CreateMap<FormVM, GetAllFormsDto>().ReverseMap();
        CreateMap<FormVM, GetFormDetailsDto>().ReverseMap();

        CreateMap<CreateFormCommand, FormVM>().ReverseMap();
        CreateMap<UpdateFormCommand, FormVM>().ReverseMap();
    }
}
