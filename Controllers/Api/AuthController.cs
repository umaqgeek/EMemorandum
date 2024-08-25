using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "TokenPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly string _secretKey;
        private readonly ApplicationDbContext _context;
        private readonly string _test;

        public AuthController(IConfiguration configuration, ApplicationDbContext context)
        {
            _secretKey = configuration.GetValue<string>("Jwt:SecretKey");
            _context = context;
            _test = configuration.GetValue<string>("test:haha");
        }

        [HttpPost("validate-me")]
        public ActionResult ValidateMe()
        {
            return Ok(new { message = "Authorized" });
        }

        [HttpGet("staff-profile/{noStaf}")]
        public ActionResult<EMO_Staf> GetStaffProfile(string noStaf)
        {
            var _entity = _context.EMO_Staf
                .Where(s => s.NoStaf == noStaf)
                .Select(s => new
                {
                    s.Nama,
                    s.Email,
                    s.NoTelBimbit,
                    s.Gelaran
                })
                .FirstOrDefault();;

            if (_entity == null)
            {
                return NotFound();
            }

            return Ok(_entity);
        }
    }
}
