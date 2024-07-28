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
        //.ForMember(dest => dest.SelectedTypeOfPropertyIds, opt => opt.MapFrom(src => src.SelectedTypeOfPropertyIds))
        //    .ForMember(dest => dest.SelectedServiceRequestIds, opt => opt.MapFrom(src => src.SelectedServiceRequestIds))
        //    .ForMember(dest => dest.SelectedPurposeOfValuationIds, opt => opt.MapFrom(src => src.SelectedPurposeOfValuationIds));
        CreateMap<UpdateFormCommand, FormVM>().ReverseMap();
    }
}
