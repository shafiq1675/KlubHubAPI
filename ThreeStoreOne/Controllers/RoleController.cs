using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetRole")]
        public IEnumerable<UserRole> GetUser()
        {
            return _roleService.GetAllUserRole().ToArray();
        }

        [HttpPost]
        public IActionResult Post(UserRole userRole)
        {
            this._roleService.AddUserRole(userRole);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserRole userRole)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("{roleId}")]
        public IActionResult Delete(string roleId)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
