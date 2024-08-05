using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
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

        /// <summary>
        /// Authenticates a user with the UTeM's SSO and return a unique resource token.
        /// </summary>
        /// <param name="login">The login model containing the email and password.</param>
        /// <returns>A unique resource token if authentication is successful.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            // TODO: Need to match with UTeM's SSO.
            if (login.Email != "testuser@gmail.com" || login.Password != "password")
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

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

        /// <summary>
        /// Logs out a user and removes them from the system.
        /// </summary>
        /// <param name="login">The login model containing the email and token.</param>
        /// <returns>A message indicating the result of the logout operation.</returns>
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] Logout logout)
        {
            // Handle logout logic.
            var user = _context.Users.SingleOrDefault(u => u.Email == logout.Email && u.Token == logout.Token); // match user's email and their existing token.
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
