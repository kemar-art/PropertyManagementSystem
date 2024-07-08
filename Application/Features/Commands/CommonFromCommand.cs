using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CommonFromCommand : IRequest<Unit>
    {
        public int FormId { get; set; }
        public string AppraiserId { get; set; } = string.Empty;
    }
}
