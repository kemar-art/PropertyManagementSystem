using MediatR;

namespace Application.Features.Queries.GetASingleForm;

public record GetFormDetailsQuery(int Id) : IRequest<GetFormDetailsDto>;
