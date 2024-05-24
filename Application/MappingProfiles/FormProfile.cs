using Application.Features.Queries.GetAllForms;
using Application.Features.Queries.GetASingleForm;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class FormProfile : Profile
    {
        public FormProfile() 
        { 
            CreateMap<Form, GetAllFormsDto>().ReverseMap();
            CreateMap<Form, GetFormDetailsDto>().ReverseMap();
        }
    }
}
