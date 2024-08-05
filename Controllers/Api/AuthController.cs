using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _secretKey;
        private readonly ApplicationDbContext _context;

        public AuthController(IConfiguration configuration, ApplicationDbContext context)
        {
            _secretKey = configuration.GetValue<string>("Jwt:SecretKey");
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            // TODO: Need to match with UTeM's SSO.
            if (login.Email != "testuser@gmail.com" || login.Password != "password")
            {
                return Unauthorized();
            }

            // return Ok(_secretKey);

            // var tokenHandler = new JwtSecurityTokenHandler();
            // var key = Encoding.ASCII.GetBytes(_secretKey);
            // var tokenDescriptor = new SecurityTokenDescriptor
            // {
            //     Subject = new ClaimsIdentity(new Claim[]
            //     {
            //         new Claim(ClaimTypes.Name, login.Username)
            //     }),
            //     Expires = DateTime.UtcNow.AddHours(1),
            //     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            // };
            // var token = tokenHandler.CreateToken(tokenDescriptor);
            // var tokenString = tokenHandler.WriteToken(token);

            // TODO: Fetch user's info from UTeM's SSO.
            var userEmail = login.Email;
            var userName = "test user";
            var tokenString = "a321shaha123dasd23234dsdw4wsdsd";

            var user = _context.Users.SingleOrDefault(u => u.Email == userEmail); // assuming you have a Password field in your User model
            if (user == null)
            {
                user = new User
                {
                    Name = userName,
                    Email = userEmail,
                    Token = tokenString
                };
                _context.Users.Add(user);
            } else {
                user.Name = userName;
                user.Email = userEmail;
                user.Token = tokenString;
            }
            _context.SaveChanges();

            return Ok(new { Token = tokenString });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] Login login)
        {
            // Handle logout logic.
            var user = _context.Users.SingleOrDefault(u => u.Email == login.Email && u.Token == login.Token); // match user's email and their existing token.
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok(new { Message = "Logged out successfully" });
            } else {
                return Ok(new { Message = "User already logged out" });
            }
        }
    }
}
