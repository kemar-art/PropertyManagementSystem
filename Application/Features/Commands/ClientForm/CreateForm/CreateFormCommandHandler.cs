using Application.Exceptions;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using MediatR;

namespace Application.Features.Commands.ClientForm.CreateForm;

public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public CreateFormCommandHandler(IMapper mapper, IFormRepository formRepository)
    {
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<int> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data
        var validator = new CreateFormCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Error submitting form for creation", validationResult);
        }

        //Convert incoming entity to domain entity
        var formToCreate = _mapper.Map<Form>(request);

        //Add to database 
        await _formRepository.CreateAsync(formToCreate);

        //Return result.
        return formToCreate.Id;
    }
}
