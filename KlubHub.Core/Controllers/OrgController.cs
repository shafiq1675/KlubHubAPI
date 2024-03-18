using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrgController : ControllerBase
    {
        private readonly IOrgService _orgService;

        public OrgController(IOrgService orgService)
        {
            _orgService = orgService;
        }

        [HttpGet("GetOrgs")]
        public IEnumerable<Org> GetOrg()
        {
            return _orgService.GetAllOrg().ToArray();
        }

        [HttpPost]
        public IActionResult Post(Org org)
        {
            try
            {
                this._orgService.AddOrg(org);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("AddOrgByAdmin")]
        public IActionResult AddOrgByAdmin(Org org)
        {
            this._orgService.AddOrg(org);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrg(Org org)
        {
            this._orgService.UpdateOrg(org);
            return Ok();
        }

        [HttpDelete("{OrgId}")]
        public IActionResult Delete(string OrgId)
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
