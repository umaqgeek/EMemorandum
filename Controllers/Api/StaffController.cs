using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize(Policy = "AdminPolicy")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EMO_Staf>> GetAllStaff()
        {
            return _context.EMO_Staf.ToList();
        }

        [HttpGet("{noStaf}")]
        public ActionResult<EMO_Staf> GetStaffProfile(string noStaf)
        {
            var _entity = _context.EMO_Staf
                .Where(s => s.NoStaf == noStaf)
                .Include(s => s.Roles)
                .FirstOrDefault();

            if (_entity == null)
            {
                return NotFound();
            }

            return Ok(_entity);
        }
    }
}
