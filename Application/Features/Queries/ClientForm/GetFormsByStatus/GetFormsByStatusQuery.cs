using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.ClientForm.GetFormsByStatus
{
    public record GetFormsByStatusQuery(string? Status) : IRequest<IEnumerable<Form>>;
}
