﻿using MediatR;

namespace Application.Features.Queries.ClientForm.GetASingleForm;

public record GetFormDetailsQuery(Guid Id) : IRequest<GetFormDetailsDto>;
