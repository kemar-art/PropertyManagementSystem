using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using MediatR;

namespace Domain.Repository_Interface;

public interface IFormRepository : IGenericRepository<Form>
{
    Task<int> CreateFrom(CreateFormCommand createForm);
}
