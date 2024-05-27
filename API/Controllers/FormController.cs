using Application.Features.Commands.CreateForm;
using Application.Features.Commands.DeleteForm;
using Application.Features.Commands.UpdateForm;
using Application.Features.Queries.GetAllForms;
using Application.Features.Queries.GetASingleForm;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<FormController>
        [HttpGet]
        public async Task<IEnumerable<GetAllFormsDto>> GetAll()
        {
            var getAllForms = await _mediator.Send(new GetFormQuery());
            return getAllForms;
        }

        // GET api/<FormController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFormDetailsDto>> Get(int id)
        {
            var getForm = await _mediator.Send(new GetFormDetailsQuery(id));
            return getForm;
        }

        // POST api/<FormController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateFormCommand createForm)
        {
            var createFormResponse = await _mediator.Send(createForm);
            return CreatedAtAction(nameof(GetAll), new { id = createFormResponse });
        }

        // PUT api/<FormController>/5
        [HttpPut("{id}")]
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
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommad = new DeleteFormCommand { Id = id };
            await _mediator.Send(deleteCommad);
            return NoContent();
        }
    }
}
