using Application.Contracts.Repository_Interface;
using Domain.CheckBoxItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurposeOfValuationItemsController : ControllerBase
    {
        private readonly ICheckBoxRepository _checkBoxRepository;

        public PurposeOfValuationItemsController(ICheckBoxRepository checkBoxRepository)
        {
            _checkBoxRepository = checkBoxRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurposeOfValuationItem>>> GetPurposeOfValuationItems()
        {
            var purposeOfValuationList = await _checkBoxRepository.GetAllPurposeOfValuationItem();
            return Ok(purposeOfValuationList);
        }
    }
}
