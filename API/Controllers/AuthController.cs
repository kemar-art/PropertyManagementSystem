using Application.AuthSettings;
using Application.Contracts.Identity;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Commands.User.UserPassword.ForgetPassword;
using Application.Features.Commands.User.UserPassword.ResetPassword;
using Domain.Common;
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
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IMediator mediator, IAuthService authService)
        {
            _logger = logger;
            _mediator = mediator;
            _authService = authService;
        }

        [HttpGet("emailcheck")]
        public async Task<ActionResult<bool>> EmailCheck(string email)
        {

            //if (string.IsNullOrEmpty(email))
            //{
            //    return BadRequest(new { errors = new { email = new[] { "" } } });
            //}


            var emailExists = await _authService.IsEmailRegisteredExist(email);
            if (emailExists)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegistrationResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegistrationResponse>> Register(ClientRegistrationCommand registerUser)
        {
            var response = await _mediator.Send(registerUser);
            return Accepted(response);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthResponse>> Login(LoginUserCommand loginUsers)
        {
            var response = await _mediator.Send(loginUsers);
            return Accepted(response);
        }

        
        [HttpPost]
        [Route("forgetpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppResponse>> ForgetPassword(ForgetPasswordRestCommand email)
        {
            var response = await _mediator.Send(email);
            return Ok(response);
        }

        [HttpPost]
        [Route("resetpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppResponse>> ResetPassword(ResetPasswordCommand resetPassword)
        {
            var response = await _mediator.Send(resetPassword);
            return Ok(response);
        }


    }
}
