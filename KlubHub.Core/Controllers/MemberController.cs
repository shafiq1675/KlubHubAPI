using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _userService;

        public MemberController(IMemberService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("GetMembers")]
        public IEnumerable<Member> GetUser()
        {
            return _userService.GetAllUser().ToArray();
        }

        [HttpPost]
        public IActionResult Post(Member member)
        {
            try
            {
                this._userService.AddMember(member);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
            
        }

        [Authorize]
        [HttpPost("AddMemberByAdmin")]
        public IActionResult AddMemberByAdmin(Member member)
        {
            this._userService.AddMember(member);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            this._userService.UpdateMember(member);
            return Ok();
        }

        [Authorize]
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
