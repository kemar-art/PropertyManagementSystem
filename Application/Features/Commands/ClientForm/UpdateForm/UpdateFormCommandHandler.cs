using Application.Contracts.ILogging;
using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Application.Features.Commands.ClientForm.UpdateForm;

public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, BaseResult<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;
    private readonly IAppLogger<UpdateFormCommandHandler> _appLogger;

    public UpdateFormCommandHandler(IMapper mapper, IFormRepository formRepository, IAppLogger<UpdateFormCommandHandler> appLogger)
    {
        _mapper = mapper;
        _formRepository = formRepository;
        _appLogger = appLogger;
    }

    public async Task<BaseResult<Unit>> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        _appLogger.LogInformation("Handling UpdateFormCommand for Form ID: {FormId}", request.Id);

        try
        {
            // Validate incoming data
            var validator = new UpdateFormCommandValidator(_formRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _appLogger.LogWarning("Validation failed for UpdateFormCommand: {ValidationErrors}", validationResult.Errors);
                return BaseResult<Unit>.Failure("Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            // Retrieve the existing form from the database
            var existingForm = await _formRepository.GetByIdAsync(request.Id);
            if (existingForm == null)
            {
                _appLogger.LogWarning("Form not found with ID: {FormId}", request.Id);
                return BaseResult<Unit>.Failure($"Form with ID {request.Id} not found.");
            }

            // Update the existing form with values from the incoming request
            _mapper.Map(request, existingForm);

            // Update in database
            var updateResult = await _formRepository.UpdateForm(existingForm);

            if (updateResult.IsSuccess)
            {
                _appLogger.LogInformation("Form updated successfully with ID: {FormId}", request.Id);
                return BaseResult<Unit>.Success(Unit.Value);
            }
            else
            {
                _appLogger.LogError("Failed to update form with ID: {FormId}", request.Id);
                return BaseResult<Unit>.Failure(updateResult.Error);
            }
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An unexpected error occurred while handling UpdateFormCommand for Form ID: {FormId}", request.Id, ex);
            return BaseResult<Unit>.Failure("An unexpected error occurred while updating form.");
        }
    }

}


