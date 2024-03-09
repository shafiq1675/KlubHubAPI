using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClubMemberController : ControllerBase
    {
        private readonly IClubMemberService _clubMemberService;

        public ClubMemberController(IClubMemberService clubMemberService)
        {
            _clubMemberService = clubMemberService;
        }

        [HttpGet("getByClubId/{clubId}")]
        public IEnumerable<ClubMemberVM> GetByClubId(int clubId)
        {
            return _clubMemberService.GetByClubId(clubId).ToArray();
        }

        [HttpGet("getByMemberId/{memberId}")]
        public IEnumerable<ClubMemberVM> GetByMemberId(int memberId)
        {
            return _clubMemberService.GetByMemberId(memberId).ToArray();
        }

        [HttpPost]
        public IActionResult Post(ClubMember club)
        {
            try
            {
                this._clubMemberService.AddClubMember(club);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateClub(ClubMember club)
        {
            this._clubMemberService.UpdateClubMember(club);
            return Ok();
        }

        [HttpDelete("{clubId}")]
        public IActionResult Delete(string clubId)
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
