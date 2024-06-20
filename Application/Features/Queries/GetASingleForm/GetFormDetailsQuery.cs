GetCardTypeQueryip57yelyelusing MediatR;

namespace Application.Features.Queries.GetASingleForm;

public record GetFormDetailsQuery(int Id) : IRequest<GetFormDetailsDto>;
