﻿using Application.Features.Commands;
using Application.Features.Commands.Appraiser.AcceptForm;
using Application.Features.Commands.Appraiser.InProcess;
using Application.Features.Commands.Appraiser.RejectForm;
using Application.Features.Commands.Appraiser.SubmitForApproval;
using Application.Features.Queries.Appriaser.GetFromForAppraiser;
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
    //[Authorize(Roles = $"{Roles.Appraiser}")]
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

        [HttpPut]
        [Route("accept")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AcceptFormByAppriaser(Guid formId)
        {
            AcceptFromCommandQuery acceptFromCommand = new()
            {
                FormId = formId
            };

            await _mediator.Send(acceptFromCommand);
            return NoContent();
        }


        [HttpPut]
        [Route("reject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RejectFormByAppriaser(Guid formId)
        {
            RejectFromCommandQuery rejectFromCommand = new()
            {
                FormId = formId
            };

            await _mediator.Send(rejectFromCommand);
            return NoContent();
        }

        [HttpPut]
        [Route("inprocess")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> MarkFormHasInProccessByAppriaser(Guid formId)
        {
            InProcessFromCommandQuery inProcessFrom = new()
            {
                FormId = formId
            };

            await _mediator.Send(inProcessFrom);
            return NoContent();
        }

        [HttpPut]
        [Route("submitted")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> SubmitFormFromApprovalByAppriaser(Guid formId, IFormFile frontImage, IFormFile leftImage, IFormFile rightImage, IFormFile backImage)
        {
            SubmitFormForApprovalQuery submitFormForApproval = new()
            {
                FormId = formId,
                FrontOfProperyImage = frontImage,
                LeftSideOfPropertImage = leftImage,
                RightSideOfPropertyImage = rightImage,
                BackOfPropertyImage = backImage
            };

            await _mediator.Send(submitFormForApproval);
            return NoContent();
        }
    }
}
