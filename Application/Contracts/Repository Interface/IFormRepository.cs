using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using Application.Features.Commands.ClientForm.UpdateForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using MediatR;

namespace Domain.Repository_Interface;

public interface IFormRepository : IGenericRepository<Form>
{
    Task<Guid> CreateFrom(CreateFormCommand createForm);
    Task<Unit> UpdateFrom(Form updateForm);
    Task<IEnumerable<Form>> GetAllFroms();
}
