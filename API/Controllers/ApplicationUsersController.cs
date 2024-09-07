using Application.Features.Commands.ClientForm.DeleteForm;
using Application.Features.Commands.User.BackOfficeUsers.CreateUser;
using Application.Features.Commands.User.BackOfficeUsers.DeleteUser;
using Application.Features.Commands.User.BackOfficeUsers.UpdateUser;
using Application.Features.Commands.User.ClientUsers.Update;
using Application.Features.Queries.Admin.Users.AppUsers.GetAllUsers;
using Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;
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
        public async Task<IEnumerable<GetAllUsersDTO>> Get()
        {
            var getAllAppUsers = await _mediator.Send(new GetAllUsersQuery());
            return getAllAppUsers;
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
        public async Task<ActionResult<BaseResult<AppResponse>>> Post([FromBody] CreateBackOfficeUserCommand createAppUser)
        {
            var result = await _mediator.Send(createAppUser);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }


        // PUT api/<ApplicationUsersController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateBackOfficeUserCommand updateAppUser)
        {
            await _mediator.Send(updateAppUser);
            return NoContent();
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
        public async Task<ActionResult> Delete(string id)
        {
            var deleteAppUser = new DeleteAppUserCommand { Id = id };
            await _mediator.Send(deleteAppUser);
            return NoContent();
        }
    }
}
