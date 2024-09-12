using Application.Contracts.ILogging;
using Application.Exceptions;
using AutoMapper;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Queries.ClientForm.GetASingleForm;

public class GetFormDetailsQueryHandler : IRequestHandler<GetFormDetailsQuery, BaseResult<GetFormDetailsDto>>
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

    public async Task<BaseResult<GetFormDetailsDto>> Handle(GetFormDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _appLogger.LogInformation("Handling GetFormDetailsQuery for Form ID: {Id}", request.Id);

            // Querying the database
            var getForm = await _formRepository.GetFormByIdAsync(request.Id);

            // Verify if the record does not exist
            if (getForm is null)
            {
                _appLogger.LogWarning("Form not found for ID: {Id}", request.Id);
                return BaseResult<GetFormDetailsDto>.Failure($"Form with ID {request.Id} not found.");
            }

            // Mapping the object from the Database to the DTO
            var mapData = _mapper.Map<GetFormDetailsDto>(getForm);
            _appLogger.LogInformation("Successfully retrieved and mapped form details for ID: {Id}", request.Id);

            return BaseResult<GetFormDetailsDto>.Success(mapData);
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An error occurred while handling GetFormDetailsQuery for Form ID: {Id}. Exception: {Exception}", request.Id, ex);
            return BaseResult<GetFormDetailsDto>.Failure("An error occurred while retrieving form details. Please try again later.");
        }
    }

}

