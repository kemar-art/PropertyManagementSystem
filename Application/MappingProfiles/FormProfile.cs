using Application.Features.Commands.ClientForm.CreateForm;
using Application.Features.Commands.ClientForm.UpdateForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetASingleForm;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class FormProfile : Profile
{
    public FormProfile() 
    {
        CreateMap<Form, GetAllFormsDto>();
        CreateMap<Form, GetFormDetailsDto>().ReverseMap();

        CreateMap<CreateFormCommand, Form>().ReverseMap();
        CreateMap<UpdateFormCommand, Form>();
    }
}
