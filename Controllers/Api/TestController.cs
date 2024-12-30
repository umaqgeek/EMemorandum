using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using EMemorandum.Models;
using EMemorandum.Services;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly DbContext_EMO _context;
    private readonly AuditLogService _auditLogService;
    private readonly string _test;

    public TestController(IConfiguration configuration, DbContext_EMO context, AuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
        _test = configuration.GetValue<string>("test:haha");
    }

    [HttpGet]
    public ActionResult Test()
    {
        return Ok(new { ayat = _test });
    }

    [HttpPost("set-token")]
    public async Task<ActionResult> SetToken([FromBody] LoginModel entity)
    {
        var user = _context.EMO_Staf.FirstOrDefault(s => s.NoStaf == entity.NoStaf);
        if (user == null) {
            return NotFound();
        }
        var _entity = new { message = "Login successful", staffId = entity.NoStaf };
        // Log the action
        await _auditLogService.AddAuditLogAsync(new MOU_AuditLog
        {
            ID = DateTime.UtcNow,
            User_ID = entity.NoStaf,
            Tarikh_Transaksi = DateTime.UtcNow,
            Proses = "Login",
            Value = Newtonsoft.Json.JsonConvert.SerializeObject(_entity),
            Nama_Table = "VEMO_Staf",
            Sub_Menu = "POST",
            Medan = "NoStaf",
            Info_Lama = null
        });

        return Ok(_entity);
    }

    /// <summary>
    /// Authenticates a user with the UTeM's SSO and return a unique resource token.
    /// </summary>
    /// <param name="login">The login model containing the email and password.</param>
    /// <returns>A unique resource token if authentication is successful.</returns>
    // [HttpPost("login")]
    // public IActionResult Login([FromBody] Login login)
    // {
    //     if (login.Email != "testuser@gmail.com" || login.Password != "password")
    //     {
    //         return Unauthorized(new { message = "Invalid username or password." });
    //     }

    //     var userEmail = login.Email;
    //     var userName = "test user";
    //     var tokenString = "a321shaha123dasd23234dsdw4wsdsd";

    //     var user = _context.Users.SingleOrDefault(u => u.Email == userEmail); // assuming you have a Password field in your User model
    //     if (user == null)
    //     {
    //         user = new User
    //         {
    //             Name = userName,
    //             Email = userEmail,
    //             Token = tokenString
    //         };
    //         _context.Users.Add(user);
    //     } else {
    //         user.Name = userName;
    //         user.Email = userEmail;
    //         user.Token = tokenString;
    //     }
    //     _context.SaveChanges();

    //     return Ok(new { Token = tokenString });
    // }

    /// <summary>
    /// Logs out a user and removes them from the system.
    /// </summary>
    /// <param name="login">The login model containing the email and token.</param>
    /// <returns>A message indicating the result of the logout operation.</returns>
    // [HttpPost("logout")]
    // public IActionResult Logout([FromBody] Logout logout)
    // {
    //     // Handle logout logic.
    //     var user = _context.Users.SingleOrDefault(u => u.Email == logout.Email && u.Token == logout.Token); // match user's email and their existing token.
    //     if (user != null)
    //     {
    //         _context.Users.Remove(user);
    //         _context.SaveChanges();
    //         return Ok(new { Message = "Logged out successfully" });
    //     } else {
    //         return Ok(new { Message = "User already logged out" });
    //     }
    // }
}

public class LoginModel
{
    public string NoStaf { get; set; }
}
