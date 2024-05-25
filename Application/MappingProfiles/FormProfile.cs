using Application.Features.Commands.CreateForm;
using Application.Features.Commands.UpdateForm;
using Application.Features.Queries.GetAllForms;
using Application.Features.Queries.GetASingleForm;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class FormProfile : Profile
    {
        public FormProfile() 
        { 
            CreateMap<Form, GetAllFormsDto>().ReverseMap();
            CreateMap<Form, GetFormDetailsDto>().ReverseMap();

            CreateMap<CreateFormCommand, Form>().ReverseMap();
            CreateMap<UpdateFormCommand, Form>().ReverseMap();
        }
    }
}
