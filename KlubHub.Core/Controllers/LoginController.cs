using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KlubHub.Model;
using KlubHub.Service;

namespace KlubHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;


        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult LogIn(Member companyUser)
        {
            var response = _loginService.ValidateUser(companyUser);
            if (response!=null)
            {
                response.Token =  this.GenToken(response);
                return Ok(response);
            }
            return NotFound();
        }

        private string GenToken(UserVM userVM)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userVM.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userVM.UserEmail),
                new Claim("UserEmail", userVM.UserEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_configuration["JwtSettings:Issuer"],
              _configuration["JwtSettings:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
