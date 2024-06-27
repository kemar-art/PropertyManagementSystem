using Application.Features.Commands.ClientForm.DeleteForm;
using Application.Features.Commands.User.AppUsers.CreateUser;
using Application.Features.Commands.User.AppUsers.DeleteUser;
using Application.Features.Commands.User.AppUsers.UpdateUser;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetASingleForm;
using Application.Features.Queries.Users.GetAllUsers;
using Application.Features.Queries.Users.GetASingleUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<GetASingleUserDTO>> Get(string id)
        {
            var getASingleUser = await _mediator.Send(new GetASingleUserDetailsQuery(id));
            return getASingleUser;
        }

        // POST api/<ApplicationUsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]CreateAppUserCommand createAppUser)
        {
            //createAppUser.Image = image;
            var createAppUserResponse = await _mediator.Send(createAppUser);
            return CreatedAtAction(nameof(Get), new { id = createAppUserResponse });
        }

        // PUT api/<ApplicationUsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UpdateAppUserCommand updateAppUser)
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
