using Application.Exceptions;
using Application.StaticDetails;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Commands.ClientForm.CreateForm;

public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public CreateFormCommandHandler(IMapper mapper, IFormRepository formRepository)
    {
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<Guid> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data
        var validator = new CreateFormCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Error submitting form for creation", validationResult);
        }

        //Convert incoming entity to domain entity
        //var formToCreate = _mapper.Map<Form>(request);
        //    formToCreate.Status = FormStatus.StatusSubmitted;
        //    formToCreate.DataCreated = DateTime.Now; 

        //Add to database 
        //await _formRepository.CreateAsync(formToCreate);

        var formToCreate = await _formRepository.CreateFrom(request);

        //Return result.
        return formToCreate;
    }
}
