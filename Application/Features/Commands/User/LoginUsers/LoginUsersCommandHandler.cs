using Application.Contracts.Repository_Interface;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.LoginUsers
{
    public class LoginUsersCommandHandler : IRequestHandler<LoginUsersCommand, Unit>
    {
        public LoginUsersCommandHandler(IUserRepository userRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            
        }
        public Task<Unit> Handle(LoginUsersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
