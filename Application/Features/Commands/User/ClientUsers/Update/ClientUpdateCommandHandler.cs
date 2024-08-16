using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Register;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers.Update
{
    public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, BaseResult<Unit>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAdminRepository _adminRepository;

        public ClientUpdateCommandHandler(IClientRepository clientRepository, IAdminRepository adminRepository)
        {
            _clientRepository = clientRepository;
            _adminRepository = adminRepository;
        }

        public async Task<BaseResult<Unit>> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {

            // Validate incoming data
            var validator = new ClientUpdateCommandValidator(_adminRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("An error was encountered when creating the user.", validationResult);
            }

            var updateClient = await _clientRepository.UpdateClient(request, request.ImagePath);
            return updateClient;
        }
    }
}