using Application.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public RolesController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetAllRoles()
        {
            var roles = await _adminRepository.GetRoles();
            return Ok(roles);
        }
    }
}
