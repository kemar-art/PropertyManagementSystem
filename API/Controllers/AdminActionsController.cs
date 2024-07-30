using Application.Features.Commands.Admin.AssignForm;
using Application.Features.Commands.Admin.CompletedForm;
using Application.Features.Commands.Admin.ReturnForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetFormsByStatus;
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
    //[Authorize(Roles = $"{Roles.Administrator}")]
    public class AdminActionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminActionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IEnumerable<Form>> GetFormByStatus(string status)
        {
            var getAllFormByStatus = await _mediator.Send(new GetFormsByStatusQuery(status));
            return getAllFormByStatus;
        }

        [HttpPut]
        [Route("assign")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AssignFormToAppraiser(AssignFormToAppraiserCommand assignFormToAppraiser)
        {
            await _mediator.Send(assignFormToAppraiser);
            return NoContent();
        }

        [HttpPut]
        [Route("complete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> MarkFormHasCompleteByAdmin(Guid formId, string appraiserId)
        {
            CompleteFromQuery completeFrom = new()
            {
                FormId = formId,
                AppraiserId = appraiserId
            };

            await _mediator.Send(completeFrom);
            return NoContent();
        }

        [HttpPut]
        [Route("retun")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ReturnFormToAppiase(Guid formId)
        {
            ReturnFormToAppraiserQuery returnFormToAppraiser = new()
            {
                FormId = formId
            };

            await _mediator.Send(returnFormToAppraiser);
            return NoContent();
        }
    }
}
