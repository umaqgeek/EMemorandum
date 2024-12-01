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
using EMemorandum.Services;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class StaffController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    private readonly IEmailService _emailService;

    public StaffController(IConfiguration configuration, ApplicationDbContext context, IEmailService emailService)
    {
        _configuration = configuration;
        _context = context;
        _emailService = emailService;
    }

    [HttpGet]
    [Authorize(Policy = "AdminPolicy")]
    public ActionResult<List<Dictionary<string, object>>> GetAllStaff()
    {
        return _context.EMO_Staf
            .Include(s => s.Roles)
                .ThenInclude(r => r.MOU_Roles)
            .AsEnumerable()
            .Select(s =>
            {
                var properties = s.GetType().GetProperties();
                var dictionary = properties.ToDictionary(
                    prop => char.ToLower(prop.Name[0]) + prop.Name.Substring(1),
                    prop => prop.GetValue(s)
                );

                // Transform specific columns
                if (dictionary.ContainsKey("roles"))
                {
                    dictionary["roles"] = s.Roles
                        .Select(r => (new
                        {
                            Code = r.MOU_Roles.Code,
                            Role = r.MOU_Roles.Role,
                        })).ToList();
                }

                return dictionary;
            })
            .ToList();
    }

    [HttpGet("less")]
    public ActionResult<IEnumerable<object>> GetAllStaffSimple()
    {
        return _context.EMO_Staf
            .Include(s => s.Roles)
            .Select(s => (new
            {
                NoStaf = s.NoStaf,
                Nama = s.Nama,
                Email = s.Email,
                Gelaran = s.Gelaran,
                Roles = s.Roles
                    .Select(r => (new
                    {
                        Code = r.MOU_Roles.Code,
                        Role = r.MOU_Roles.Role,
                    })).ToList(),
            }))
            .ToList();
    }

    [HttpGet("less/{noStaf}")]
    public ActionResult<EMO_Staf> GetStaffProfileLess(string noStaf)
    {
        var _entity = _context.EMO_Staf
            .Where(s => s.NoStaf == noStaf)
            .Include(s => s.Roles)
            .Select(s => new
            {
                Email = s.Email,
                Gelaran = s.Gelaran,
                Nama = s.Nama,
                NoStaf = s.NoStaf,
                NoTelBimbit = s.NoTelBimbit,
                NPejabat = s.NPejabat,
                Roles = s.Roles,
            })
            .FirstOrDefault();

        if (_entity == null)
        {
            return NotFound();
        }

        return Ok(_entity);
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

        if (!string.IsNullOrWhiteSpace(_entity.Email))
        {
            SendEmailInBackground(_entity);
        }

        return Ok(_entity);
    }

    private void SendEmailInBackground(EMO_Staf _entity)
    {
        var EMOURL = _configuration.GetValue<string>("EMOURL");
        var subject = "Account Activation";
        var gelaran = _entity.Gelaran.Contains("TIADA DILAPORKAN", StringComparison.OrdinalIgnoreCase) ? "" : _entity.Gelaran;
        var body = "<p>" + gelaran + " " + _entity.Nama + "</p>"
                    + "<p>Your account has been updated. Please click this link "
                    + $"<a target='_blank' href='{EMOURL}?UsrLogin={_entity.NoStaf}'>{EMOURL}</a>"
                    + " for more info.</p>";

        // Run email sending in the background
        Task.Run(async () =>
        {
            await _emailService.SendEmailAsync(_entity.Email, subject, body);
        });
    }

    private string GetStaffID()
    {
        // Fetch the token from the Authorization header
        var authHeader = Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader != null && authHeader.StartsWith("Bearer "))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }
        return null;
    }
}

public class AssignRolesRequest
{
    public List<string> Roles { get; set; }
}

