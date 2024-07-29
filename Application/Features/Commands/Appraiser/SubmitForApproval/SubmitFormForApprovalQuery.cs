using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appraiser.SubmitForApproval
{
    public class SubmitFormForApprovalQuery : CommonFromPropertires, IRequest<Unit>
    {
        public IFormFile? FrontOfProperyImage { get; set; }
        public IFormFile? RightSideOfPropertyImage { get; set; }
        public IFormFile? LeftSideOfPropertImage { get; set; }
        public IFormFile? BackOfPropertyImage { get; set; }
    }
}
