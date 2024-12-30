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

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "AdminPolicy")]
public class AuditLogController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public AuditLogController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetMOUAuditLogs()
    {
        return await _context.MOU_AuditLog
            .Include(m => m.EMO_Staf)
            .Select(m => new
            {
                ID = m.ID,
                User = m.EMO_Staf == null ? null : new
                {
                    NoStaf = m.EMO_Staf.NoStaf,
                    Nama = m.EMO_Staf.Nama,
                    Gelaran = m.EMO_Staf.Gelaran,
                },
                Proses = m.Proses,
                DateTime = m.ID.ToString("dd/MM/yyyy, h:mm:ss tt")
            })
            .OrderByDescending(m => m.ID)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MOU_AuditLog>> GetMOUAuditLog(int id)
    {
        var auditLog = await _context.MOU_AuditLog.FindAsync(id);

        if (auditLog == null)
        {
            return NotFound();
        }

        return auditLog;
    }
}
