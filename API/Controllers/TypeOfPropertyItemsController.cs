using Application.Contracts.Repository_Interface;
using Domain.CheckBoxItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfPropertyItemsController : ControllerBase
    {
        private readonly ICheckBoxRepository _checkBoxRepository;

        public TypeOfPropertyItemsController(ICheckBoxRepository checkBoxRepository)
        {
            _checkBoxRepository = checkBoxRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeOfPropertyItem>>> GetAllTypeOfPropertyItems()
        {
            var typeOfPropertyList = await _checkBoxRepository.GetAllTypeOfPropertyItem();
            return Ok(typeOfPropertyList);
        }
    }
}
