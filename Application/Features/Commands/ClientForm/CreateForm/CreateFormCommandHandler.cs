using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.StaticDetails;
using AutoMapper;
using Domain;
using Domain.BaseResponse;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Commands.ClientForm.CreateForm;

public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, BaseResult<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;
    private readonly IAppLogger<CreateFormCommandHandler> _appLogger;

    public CreateFormCommandHandler(IMapper mapper, IFormRepository formRepository, IAppLogger<CreateFormCommandHandler> appLogger)
    {
        _mapper = mapper;
        _formRepository = formRepository;
        _appLogger = appLogger;
    }

    public async Task<BaseResult<Guid>> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateFormCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            _appLogger.LogWarning("Validation failed for CreateFormCommand: {ValidationErrors}", validationResult.Errors);
            return BaseResult<Guid>.Failure("Validation errors occurred.");
        }

        try
        {
            // Convert incoming entity to domain entity
            var formToCreate = await _formRepository.CreateFrom(request);

            if (!formToCreate.IsSuccess)
            {
                _appLogger.LogError("Failed to create form with ID {FormId}", formToCreate.Id);
                return BaseResult<Guid>.Failure("Failed to create form.");
            }

            _appLogger.LogInformation("Form created successfully with ID: {FormId}", formToCreate.Value);
            return BaseResult<Guid>.Success(formToCreate.Value);
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An unexpected error occurred while handling CreateFormCommand. Exception: {ExceptionMessage}", ex.Message);
            return BaseResult<Guid>.Failure("An unexpected error occurred while creating the form.");
        }
    }

}
