using Application.Contracts.ILogging;
using AutoMapper;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Queries.ClientForm.GetAllForms;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, BaseResult<IEnumerable<GetAllFormsDto>>>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;
    private readonly IAppLogger<GetFormQueryHandler> _appLogger;

    public GetFormQueryHandler(IMapper mapper, IFormRepository formRepository, IAppLogger<GetFormQueryHandler> appLogger)
    {
        _mapper = mapper;
        _formRepository = formRepository;
        _appLogger = appLogger;
    }

    public async Task<BaseResult<IEnumerable<GetAllFormsDto>>> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _appLogger.LogInformation("Handling GetFormQuery to retrieve all forms.");

            // Querying the database to get all forms
            var getAllForms = await _formRepository.GetAllForms();

            // If no forms are found, log a warning and return an empty list
            if (!getAllForms.Any())
            {
                _appLogger.LogWarning("No forms found.");
                return BaseResult<IEnumerable<GetAllFormsDto>>.Success(Enumerable.Empty<GetAllFormsDto>());
            }

            // Mapping the retrieved forms to the DTO
            var mapData = _mapper.Map<IEnumerable<GetAllFormsDto>>(getAllForms);
            _appLogger.LogInformation("Successfully retrieved and mapped all forms.");

            return BaseResult<IEnumerable<GetAllFormsDto>>.Success(mapData);
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An error occurred while handling GetFormQuery. Exception: {Exception}", ex);
            return BaseResult<IEnumerable<GetAllFormsDto>>.Failure("An error occurred while retrieving forms. Please try again later.");
        }
    }

}
