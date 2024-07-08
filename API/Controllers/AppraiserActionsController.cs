using Application.Features.Queries.ClientForm.GetFormsByStatus;
using Application.Features.Queries.ClientForm.GetFromForAppraiser;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.SeedConfig.UserRole;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Roles.Appraiser}")]
    public class AppraiserActionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppraiserActionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IEnumerable<Form>> GetFormForAppraiser()
        {
            var getFormForAppraiser = await _mediator.Send(new GetFromForAppraiserQuery());
            return getFormForAppraiser;
        }
    }
}
