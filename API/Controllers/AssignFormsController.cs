using Application.Features.Commands.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.SeedConfig;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Roles.Administrator}")]
    public class AssignFormsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssignFormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AssignFormToAppraiser([FromForm] AssignFormToAppraiserCommand assignFormToAppraiser)
        {
            await _mediator.Send(assignFormToAppraiser);
            return NoContent();
        }
    }
}
