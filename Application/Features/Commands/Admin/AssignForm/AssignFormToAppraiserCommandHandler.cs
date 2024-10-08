﻿using Application.Contracts.Repository_Interface;
using Domain.Repository_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Admin.AssignForm
{
    public class AssignFormToAppraiserCommandHandler : IRequestHandler<AssignFormToAppraiserCommand, Unit>
    {
        private readonly IAdminRepository _adminRepository;

        public AssignFormToAppraiserCommandHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Unit> Handle(AssignFormToAppraiserCommand request, CancellationToken cancellationToken)
        {
            var assignForm = await _adminRepository.AssignJob(request);
            return assignForm;
        }
    }
}
