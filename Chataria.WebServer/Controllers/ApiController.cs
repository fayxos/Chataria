using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chataria.WebServer.Controllers
{
    /// <summary>
    /// Manages the Web API calls
    /// </summary>
    public class ApiController : Controller
    {
        [Route("api/login")]
        public IActionResult LogIn()
        {
            // TODO: Get users login information and check its correct

            var username = "fayxos";
            var email = "felixhaag@hotmail.de";

            // Set our tokens claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.NameId, "unknownuser"),                
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("my key", "my value")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"]));
        }
    }
}
