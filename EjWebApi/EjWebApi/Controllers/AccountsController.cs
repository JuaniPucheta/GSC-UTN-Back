using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EjWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        //[AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, "admin") },
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signingCredentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            string jwt = tokenHandler.WriteToken(securityToken);

            return this.Ok(jwt);

        }
    }
}
