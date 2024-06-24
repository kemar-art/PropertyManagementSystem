using Application.Exceptions;
using Application.Features.Commands.Client.UpdateForm;
using Application.Features.Commands.CreateForm;
using Application.Features.Commands.UpdateForm;
using Application.Features.Queries.GetASingleForm;
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
        //Validate incoming data
        var validator = new UpdateFormCommandValidator(_formRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Error submitting form for update", validationResult);
        }

        //Convert incoming entity to domain entity
        var formToUpdate = _mapper.Map<Form>(request);

        //Add to database 
        await _formRepository.UpdateAsync(formToUpdate);

        //Return result.
        return Unit.Value;
    }
}
