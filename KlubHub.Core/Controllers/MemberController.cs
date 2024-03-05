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
        private readonly IMemberService _userService;

        public MemberController(IMemberService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetMembers")]
        public IEnumerable<Member> GetUser()
        {
            return _userService.GetAllUser().ToArray();
        }

        [HttpPost]
        public IActionResult Post(Member member)
        {
            this._userService.AddMember(member);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            this._userService.UpdateMember(member);
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
