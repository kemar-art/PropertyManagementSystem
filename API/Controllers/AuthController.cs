using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Register(ClientUserCommand registerUser)
        {
             var response = await _mediator.Send(registerUser);
            return Accepted(response);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(LoginUserCommand loginUsers)
        {
            var response = await _mediator.Send(loginUsers);
            return Accepted(response);
        }
    }
}
