using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Appriaser.GetFromForAppraiser
{
    public record GetFromForAppraiserQuery : IRequest<IEnumerable<Form>>;
}
