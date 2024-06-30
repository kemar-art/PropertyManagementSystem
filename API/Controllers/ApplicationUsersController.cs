using Application.Features.Commands.ClientForm.DeleteForm;
using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.DeleteUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetASingleForm;
using Application.Features.Queries.Users.AppUsers.GetAllUsers;
using Application.Features.Queries.Users.AppUsers.GetASingleUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.SeedConfig.UserRole;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Roles.Administrator}")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetASingleUserDTO>> Get(string id)
        {
            var getASingleUser = await _mediator.Send(new GetASingleUserDetailsQuery(id));
            return getASingleUser;
        }

        // POST api/<ApplicationUsersController>
        [HttpPost]
        //[Route("create/employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Post([FromForm] CreateAppUserCommand createAppUser)
        {
            //createAppUser.Image = image;
            var createAppUserResponse = await _mediator.Send(createAppUser);
            return CreatedAtAction(nameof(Get), new { id = createAppUserResponse });
        }

        // PUT api/<ApplicationUsersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromForm] UpdateAppUserCommand updateAppUser)
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
