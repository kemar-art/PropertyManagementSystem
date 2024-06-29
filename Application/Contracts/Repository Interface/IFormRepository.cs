using Application.Features.Commands.Admin;
using MediatR;

namespace Domain.Repository_Interface;

public interface IFormRepository : IGenericRepository<Form>
{
    Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser);
}
