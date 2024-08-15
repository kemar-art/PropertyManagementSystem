using Application.Features.Commands.ClientForm.CreateForm;
using Application.Features.Commands.ClientForm.DeleteForm;
using Application.Features.Commands.ClientForm.UpdateForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.Features.Queries.ClientForm.GetASingleForm;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<FormController>
        [HttpGet]
        public async Task<IEnumerable<GetAllFormsDto>> Get()
        {
            var getAllForms = await _mediator.Send(new GetFormQuery());
            return getAllForms;
        }

        // GET api/<FormController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetFormDetailsDto>> Get(Guid id)
        {
            var getForm = await _mediator.Send(new GetFormDetailsQuery(id));
            return Ok(getForm);
        }

        // POST api/<FormController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Post(CreateFormCommand createForm)
        {
            var result = await _mediator.Send(createForm);
            return CreatedAtAction(nameof(Get), new { id = result.Value }, result.Value);
        }

        // PUT api/<FormController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateFormCommand updateForm)
        {
            await _mediator.Send(updateForm);
            return NoContent();
        }

        // DELETE api/<FormController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCommad = new DeleteFormCommand { Id = id };
            await _mediator.Send(deleteCommad);
            return NoContent();
        }
    }
}
