using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IUserService _userService;

        public MemberController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetMembers")]
        public IEnumerable<Member> GetUser()
        {
            return _userService.GetAllUser().ToArray();
        }

        [HttpPost]
        public IActionResult Post(Member companyUser)
        {
            this._userService.AddUser(companyUser);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMember(Member companyUser)
        {
            this._userService.UpdateUser(companyUser);
            return Ok();
        }

        [HttpDelete("{UserId}")]
        public IActionResult Delete(string UserId)
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
