using Application.Contracts.ILogging;
using Application.Exceptions;
using AutoMapper;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Queries.GetASingleForm;

public class GetFormDetailsQueryHandler : IRequestHandler<GetFormDetailsQuery, GetFormDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;
    private readonly IAppLogger<GetFormDetailsQueryHandler> _appLogger;

    public GetFormDetailsQueryHandler(IMapper mapper, IFormRepository formRepository, IAppLogger<GetFormDetailsQueryHandler> appLogger)
    {
        _mapper = mapper;
        _formRepository = formRepository;
        _appLogger = appLogger;
    }

    public async Task<GetFormDetailsDto> Handle(GetFormDetailsQuery request, CancellationToken cancellationToken)
    {
        //Querying the database
        var getForm = await _formRepository.GetByIdAsync(request.Id);

        //Verify if the record exist
        if (getForm is null)
        {
            throw new NotFoundException(nameof(getForm), request.Id);
        }

        //Mapping the object from the Database to the Dto
        var mapData = _mapper.Map<GetFormDetailsDto>(request);

        return mapData;
    }
}

