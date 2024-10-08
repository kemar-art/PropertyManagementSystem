﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin.AssignForm
{
    public class AssignFormToAppraiserCommand : CommonFromPropertires, IRequest<Unit>
    {
        //public int FormId { get; set; }
        //public string AppraiserId { get; set; } = string.Empty;
        public string AdminNote { get; set; } = string.Empty;
    }
}
