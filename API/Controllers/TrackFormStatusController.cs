using Domain;
using Domain.Repository_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackFormStatusController : ControllerBase
    {
        private readonly IFormRepository _formRepository;

        public TrackFormStatusController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        [HttpGet("{formId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrackFormResult>> TrackTheStatusOfTheForm(int formId)
        {
            if (formId <= 0)
            {
                return BadRequest("Invalid form ID.");
            }

            var result = await _formRepository.TrackForm(formId);

            if (!result.Exists)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
