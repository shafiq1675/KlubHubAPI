using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MemberRoleController : ControllerBase
    {
        private readonly IMemberRoleService _MemberRoleService;

        public MemberRoleController(IMemberRoleService MemberRoleService)
        {
            _MemberRoleService = MemberRoleService;
        }

        [HttpGet("GetRole")]
        public IEnumerable<MemberRole> GetUser()
        {
            return _MemberRoleService.GetAllMemberRole().ToArray();
        }

        [HttpPost]
        public IActionResult Post(MemberRole MemberRole)
        {
            this._MemberRoleService.AddMemberRole(MemberRole);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(MemberRole MemberRole)
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
