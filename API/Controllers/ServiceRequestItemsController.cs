using Application.Contracts.Repository_Interface;
using Domain.CheckBox.ServiceRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestItemsController : ControllerBase
    {
        private readonly ICheckBoxRepository _checkBoxRepository;

        public ServiceRequestItemsController(ICheckBoxRepository checkBoxRepository)
        {
            _checkBoxRepository = checkBoxRepository;
        }

        [HttpGet]

        public async Task<ActionResult<List<ServiceRequestItem>>> GetAllServiceRequestItems()
        {
            var serviceRequestList = await _checkBoxRepository.GetAllServiceRequestItem();
            return Ok(serviceRequestList);
        }
    }
}
