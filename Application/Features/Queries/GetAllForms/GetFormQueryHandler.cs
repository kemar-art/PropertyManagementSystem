using AutoMapper;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllForms;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, IEnumerable<GetAllFormsDto>>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public GetFormQueryHandler(IMapper mapper, IFormRepository formRepository) 
    {
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<IEnumerable<GetAllFormsDto>> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        var getAllForms = await _formRepository.GetAllAsync();

        var mapData =_mapper.Map<IEnumerable<GetAllFormsDto>>(getAllForms);

        return mapData;
    }
}
