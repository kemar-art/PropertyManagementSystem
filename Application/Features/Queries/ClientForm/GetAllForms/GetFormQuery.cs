using Domain.Common;
using MediatR;

namespace Application.Features.Queries.ClientForm.GetAllForms;

public record GetFormQuery : IRequest<BaseResult<IEnumerable<GetAllFormsDto>>>;
