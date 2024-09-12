using Application.Features.Commands.ClientForm.DeleteForm;
using Application.Features.Commands.User.BackOfficeUsers.CreateUser;
using Application.Features.Commands.User.BackOfficeUsers.DeleteUser;
using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers.Update;
using Application.Features.Queries.Admin.Users.BackOficeUsers;
using Application.Features.Queries.Admin.Users.ClientUsers;
using Application.Features.Queries.Admin.Users.SingleUser;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.SeedConfig.UserRole;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = $"{Roles.Administrator}")]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ApplicationUsersController>
        [HttpGet]
        [Route("admins")]
        public async Task<IEnumerable<GetAllBackOfficeUsersDTO>> GetAllBackOfficeUsers()
        {
            var users = await _mediator.Send(new GetAllBackOfficeUsersQuery());
            return users;
        }

        [HttpGet]
        [Route("cliets")]
        public async Task<IEnumerable<GetAllClientUsersDTO>> GetAllClientUsers()
        {
            var users = await _mediator.Send(new GetAllClientUsersQuery());
            return users;
        }

        // GET api/<ApplicationUsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetASingleUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetASingleUserDTO>> Get(string id)
        {
            var getASingleUser = await _mediator.Send(new GetASingleUserDetailsQuery(id));
            return Ok(getASingleUser);
        }

        // POST api/<ApplicationUsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<BaseResult<CustomResponse>>> Post([FromBody] CreateBackOfficeUserCommand createAppUser)
        {
            var result = await _mediator.Send(createAppUser);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }


        // PUT api/<ApplicationUsersController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResult<CustomResponse>>> Put([FromBody] UpdateBackOfficeUserCommand updateAppUser)
        {
            var result = await _mediator.Send(updateAppUser);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateclient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateClient([FromBody] ClientUpdateCommand updateAppUser)
        {
            await _mediator.Send(updateAppUser);
            return NoContent();
        }

        // DELETE api/<ApplicationUsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomResponse>> Delete(string id)
        {
            var user = new DeleteAppUserCommand { Id = id };
            var deletedUser = await _mediator.Send(user);
            return Ok(deletedUser);
        }
    }
}
