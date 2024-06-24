using MediatR;

namespace Application.Features.Queries.ClientForm.GetAllForms;

public record GetFormQuery : IRequest<IEnumerable<GetAllFormsDto>>;
