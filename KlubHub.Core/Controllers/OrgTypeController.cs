using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrgTypeController : ControllerBase
    {
        private readonly IOrgTypeService _orgTypeService;

        public OrgTypeController(IOrgTypeService orgTypeService)
        {
            _orgTypeService = orgTypeService;
        }

        [HttpGet("GetOrgTypes")]
        public IEnumerable<OrgType> GetOrgType()
        {
            return _orgTypeService.GetAllOrgType().ToArray();
        }

        [HttpPost]
        public IActionResult Post(OrgType orgType)
        {
            try
            {
                this._orgTypeService.AddOrgType(orgType);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPost("AddOrgTypeByAdmin")]
        public IActionResult AddOrgTypeByAdmin(OrgType orgType)
        {
            this._orgTypeService.AddOrgType(orgType);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateOrgType(OrgType orgType)
        {
            this._orgTypeService.UpdateOrgType(orgType);
            return Ok();
        }

        [HttpDelete("{OrgTypeId}")]
        public IActionResult Delete(string OrgTypeId)
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
