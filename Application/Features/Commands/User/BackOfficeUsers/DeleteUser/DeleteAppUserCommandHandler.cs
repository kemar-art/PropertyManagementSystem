using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands.ClientForm.DeleteForm;
using Domain.Common;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.BackOfficeUsers.DeleteUser
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, CustomResponse>
    {
        private readonly IAdminRepository _userRepository;

        public DeleteAppUserCommandHandler(IAdminRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CustomResponse> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new CustomResponse { IsSuccess = false, Message = "A value was not send for Id"};
            }

            var result = await _userRepository.DeleteAllUsers(request.Id);

            return result;
        }
    }
}
