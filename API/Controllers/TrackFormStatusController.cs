using Domain;
using Domain.Repository_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.SeedConfig.UserRole;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [Authorize(Roles =Roles.Client)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrackFormStatusController : ControllerBase
    {
        private readonly IFormRepository _formRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TrackFormStatusController(IFormRepository formRepository, IHttpContextAccessor httpContextAccessor)
        {
            _formRepository = formRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{formId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
