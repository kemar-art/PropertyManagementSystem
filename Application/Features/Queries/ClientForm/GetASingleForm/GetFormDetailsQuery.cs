using MediatR;

namespace Application.Features.Queries.ClientForm.GetASingleForm;

public record GetFormDetailsQuery(int Id) : IRequest<GetFormDetailsDto>;
