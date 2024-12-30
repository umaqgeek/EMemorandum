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
[Authorize(Policy = "TokenPolicy")]
public class AuthController : ControllerBase
{
    private readonly DbContext_EMO _context;
    private readonly AuditLogService _auditLogService;

    public AuthController(IConfiguration configuration, DbContext_EMO context, AuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    [HttpPost("validate-me")]
    public ActionResult ValidateMe()
    {
        return Ok(new { message = "Authorized" });
    }

    [HttpPost("unset-token")]
    public async Task<ActionResult> UnsetToken()
    {
        var staffID = GetStaffID();
        var _entity = new { message = "Logout successful", staffId = staffID };
        // Log the action
        await _auditLogService.AddAuditLogAsync(new MOU_AuditLog
        {
            ID = DateTime.UtcNow,
            User_ID = staffID,
            Tarikh_Transaksi = DateTime.UtcNow,
            Proses = "Logout",
            Value = Newtonsoft.Json.JsonConvert.SerializeObject(_entity),
            Nama_Table = "VEMO_Staf",
            Sub_Menu = "POST",
            Medan = "NoStaf",
            Info_Lama = null
        });

        return Ok(_entity);
    }

    [HttpGet("staff-profile")]
    public ActionResult<EMO_Staf> GetStaffProfile()
    {
        var staffID = GetStaffID();
        var _entity = _context.EMO_Staf
            .Where(s => s.NoStaf == staffID)
            .Include(s => s.Roles)
            .Select(s => new
            {
                s.Nama,
                s.Email,
                s.NoTelBimbit,
                s.Gelaran,
                s.JGiliran,
                Roles = s.Roles.Select(r => (new
                {
                    Code = r.MOU_Roles.Code,
                    Role = r.MOU_Roles.Role,
                })).ToList(),
                s.NoStaf,
            })
            .FirstOrDefault();

        if (_entity == null)
        {
            return NotFound();
        }

        return Ok(_entity);
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
