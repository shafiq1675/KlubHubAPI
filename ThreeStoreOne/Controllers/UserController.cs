using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public IEnumerable<CompanyUser> GetUser()
        {
            return _userService.GetAllUser().ToArray();
        }

        [HttpPost]
        public IActionResult Post(CompanyUser companyUser)
        {
            this._userService.AddUser(companyUser);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(CompanyUser companyUser)
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
