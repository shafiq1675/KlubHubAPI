using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
        [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public IEnumerable<Club> Get()
        {
            return _clubService.Get().ToArray();
        }

        [HttpGet("getById/{clubId}")]

        public Club Get(int clubId)
        {
            return _clubService.Get(clubId);
        }

        [HttpPost]
        public IActionResult Post(Club club)
        {
            try
            {
                this._clubService.AddClub(club);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
            
        }


        [HttpPut]
        public IActionResult UpdateClub(Club club)
        {
            this._clubService.UpdateClub(club);
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
