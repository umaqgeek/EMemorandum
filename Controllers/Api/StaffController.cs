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
    [Authorize(Policy = "StaffPolicy")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public ActionResult<IEnumerable<EMO_Staf>> GetAllStaff()
        {
            // Fetch the token from the Authorization header
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader == null || !authHeader.StartsWith("Bearer ")) {
                return Unauthorized("Token is missing or invalid.");
            }
            var staffId = authHeader.Substring("Bearer ".Length).Trim();

            return _context.EMO_Staf
                .Where(s => s.NoStaf != staffId)
                .Include(s => s.Roles)
                .ToList();
        }

        [HttpGet("less")]
        public ActionResult<IEnumerable<object>> GetAllStaffSimple()
        {
            // Fetch the token from the Authorization header
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader == null || !authHeader.StartsWith("Bearer ")) {
                return Unauthorized("Token is missing or invalid.");
            }
            var staffId = authHeader.Substring("Bearer ".Length).Trim();

            return _context.EMO_Staf
                .Where(s => s.NoStaf != staffId)
                .Include(s => s.Roles)
                .Select(s => (new {
                    Email = s.Email,
                    Gelaran = s.Gelaran,
                    Nama = s.Nama,
                    NoStaf = s.NoStaf,
                    Roles = s.Roles,
                }))
                .ToList();
        }

        [HttpGet("{noStaf}")]
        [Authorize(Policy = "AdminPolicy")]
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

        [HttpPost("assign-role/{noStaf}")]
        [Authorize(Policy = "AdminPolicy")]
        public ActionResult AssignStaffRoles(string noStaf, [FromBody] AssignRolesRequest request)
        {
            // Retrieve the staff entity including its roles
            var _entity = _context.EMO_Staf
                .Where(s => s.NoStaf == noStaf)
                .Include(s => s.Roles)
                .FirstOrDefault();

            // Check if the staff exists
            if (_entity == null)
            {
                return NotFound();
            }

            // Clear existing roles if necessary (optional)
            _entity.Roles.Clear();

            // Assign new roles to the staff
            foreach (var role in request.Roles)
            {
                var staffRole = new EMO_Roles
                {
                    NoStaf = noStaf,
                    Role = role
                };

                _entity.Roles.Add(staffRole);
            }

            // Save changes to the database
            _context.SaveChanges();

            return Ok(_entity);
        }
    }
}

public class AssignRolesRequest
{
    public List<string> Roles { get; set; }
}

