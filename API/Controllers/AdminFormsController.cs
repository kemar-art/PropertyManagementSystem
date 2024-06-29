using Application.Features.Commands.Admin;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetFormsByStatus;
using Domain;
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
    public class AdminFormsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminFormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Form>> GetFormByStatus(string status)
        {
            var getAllFormByStatus = await _mediator.Send(new GetFormsByStatusQuery(status));
            return getAllFormByStatus;
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
