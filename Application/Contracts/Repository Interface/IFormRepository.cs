using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using Application.Features.Commands.ClientForm.UpdateForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using Domain.Common;
using MediatR;

namespace Domain.Repository_Interface;

public interface IFormRepository : IGenericRepository<Form>
{
    Task<BaseResult<Guid>> CreateFrom(CreateFormCommand createForm);
    Task<BaseResult<Unit>> UpdateForm(Form updateForm);
    Task<IEnumerable<Form>> GetAllForms();
    Task<TrackFormResult> TrackForm(int formId);
}
