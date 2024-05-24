using AutoMapper;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetASingleForm;

public class GetFormDetailsQueryHandler : IRequestHandler<GetFormDetailsQuery, GetFormDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public GetFormDetailsQueryHandler(IMapper mapper, IFormRepository formRepository)
    {
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<GetFormDetailsDto> Handle(GetFormDetailsQuery request, CancellationToken cancellationToken)
    {
        //Querying the database
        var getForm = await _formRepository.GetByIdAsync(request.Id);

        //Mapping the object from the Database to the Dto
        var mapData = _mapper.Map<GetFormDetailsDto>(request);

        return mapData;
    }
}

