using Application.Contracts.Repository_Interface;
using Application.Features.Queries.ClientForm.GetAllForms;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetAllRegion()
        {
            var getAllRegions = await _regionRepository.GetAllAsync();
            return Ok(getAllRegions);
        }
    }
}
