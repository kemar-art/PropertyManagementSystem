using MediatR;

namespace Application.Features.Queries.GetAllForms;

public record GetFormQuery : IRequest<IEnumerable<GetAllFormsDto>>;
