using Application.Contracts.ILogging;
using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Application.Features.Commands.ClientForm.UpdateForm;

public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Unit>
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

    public async Task<Unit> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _appLogger.LogInformation("Handling UpdateFormCommand for Form ID: {FormId}", request.Id);

            // Validate incoming data
            var validator = new UpdateFormCommandValidator(_formRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _appLogger.LogWarning("Validation failed for UpdateFormCommand: {ValidationErrors}", validationResult.Errors);
                throw new BadRequestException("Error submitting form for update", validationResult);
            }

            // Retrieve the existing form from the database
            var existingForm = await _formRepository.GetByIdAsync(request.Id);
            if (existingForm == null)
            {
                _appLogger.LogWarning("Form not found with ID: {FormId}", request.Id);
                throw new NotFoundException(nameof(Form), request.Id);
            }

            // Update the existing form with values from the incoming request
            _mapper.Map(request, existingForm);
            // Ensure CustomerId is not being modified
            //existingForm.CustomerId = existingForm.CustomerId; // No need to reassign

            // Update in database
            var updatedForm = await _formRepository.UpdateFrom(existingForm);

            _appLogger.LogInformation("Form updated successfully with ID: {FormId}", request.Id);

            // Return result
            return updatedForm;
        }
        catch (DbUpdateException ex)
        {
            _appLogger.LogError("An error occurred while updating the form with ID: {FormId}. Inner exception: {InnerException}", request.Id, ex.InnerException?.Message, ex);
            throw new Exception("An error occurred while updating the form. Please check the inner exception for details.", ex);
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An unexpected error occurred while updating the form with ID: {FormId}", request.Id, ex);
            throw new Exception("An unexpected error occurred.", ex);
        }
    }

}


