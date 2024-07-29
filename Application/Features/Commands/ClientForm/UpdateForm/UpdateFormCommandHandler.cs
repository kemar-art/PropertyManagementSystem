using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Commands.ClientForm.UpdateForm;

public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public UpdateFormCommandHandler(IMapper mapper, IFormRepository formRepository)
    {
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<Unit> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateFormCommandValidator(_formRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Error submitting form for update", validationResult);
        }

        // Retrieve the existing form from the database
        var existingForm = await _formRepository.GetByIdAsync(request.Id);
        if (existingForm == null)
        {
            throw new NotFoundException(nameof(Form), request.Id);
        }

        // Update the existing form with values from the incoming request
        _mapper.Map(request, existingForm);

        // Update in database
        await _formRepository.UpdateAsync(existingForm);

        // Return result.
        return Unit.Value;
    }

}