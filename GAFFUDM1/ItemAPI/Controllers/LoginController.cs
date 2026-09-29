using ItemDataLibrary.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ISqlData _db;

        public LoginController(IConfiguration config, ISqlData db)
        {
            _config = config;
            _db = db;
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // POST: api/Login/login
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserModel login)
        {
            var user = _db.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            var token = GenerateToken(user);
            return Ok(new { token = token });
        }

        // POST: api/Login/register
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Register([FromBody] UserModel user)
        {
            _db.Register(user.UserName, user.Password);
            return Ok("User registered.");
        }
    }
}