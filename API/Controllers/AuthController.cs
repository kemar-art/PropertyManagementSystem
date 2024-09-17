using Application.AuthSettings;
using Application.Contracts.Identity;
using Application.Features.Commands.User.ClientUsers.Register;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Commands.User.UserPassword.ForgetPassword.Admins;
using Application.Features.Commands.User.UserPassword.ForgetPassword.Clients;
using Application.Features.Commands.User.UserPassword.ResetPassword.LoginUserPasswordReset;
using Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> EmailCheck(string email)
        {
            var result = await _authService.IsEmailRegisteredExist(email);

            // Return the result based on the success or failure of the service method
            return result.IsSuccess ? Ok(result.Value) : StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while checking the email.");
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegistrationResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegistrationResponse>> Register(ClientRegistrationCommand registerUser)
        {
            var response = await _mediator.Send(registerUser);
            return Accepted(response.Value);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthResponse>> Login(LoginUserCommand loginUsers)
        {
            var response = await _mediator.Send(loginUsers);
            return Accepted(response.Value);
        }

        
        [HttpPost]
        [Route("client")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResponse>> ForgetPassword(ForgetPasswordRestCommand email)
        {
            var response = await _mediator.Send(email);
            return Ok(response);
        }

        [HttpPost]
        [Route("admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResponse>> AdminForgetPassword(AdminForgetPasswordRestCommand email)
        {
            var response = await _mediator.Send(email);
            return Ok(response);
        }

        [HttpPost]
        [Route("resetpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResponse>> ResetPassword(NoneLoginUserPasswordResetCommand noneLoginUser)
        {

            var response = await _mediator.Send(noneLoginUser);
            return Ok(response);
        }

        [HttpPost]
        [Route("updatepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResponse>> UpdateResetPassword(LoginUserPasswordResetCommand loginUser)
        {

            var response = await _mediator.Send(loginUser);
            return Ok(response);
        }


    }
}
