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
public class EMOKPIController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public EMOKPIController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EMO_KPI>>> GetEMOKPIs()
    {
        return await _context.EMO_KPI.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EMO_KPI>> GetEMOKPI(string id)
    {
        var emoKpi = await _context.EMO_KPI.FindAsync(id);

        if (emoKpi == null)
        {
            return NotFound();
        }

        return emoKpi;
    }

    [HttpPost]
    public async Task<ActionResult<EMO_KPI>> PostEMOKPI(EMO_KPI emoKpi)
    {
        _context.EMO_KPI.Add(emoKpi);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEMOKPI), new { id = emoKpi.Kod }, emoKpi);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEMOKPI(string id, EMO_KPI emoKpi)
    {
        if (id != emoKpi.Kod)
        {
            return BadRequest();
        }

        _context.Entry(emoKpi).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EMOKPIExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEMOKPI(string id)
    {
        var emoKpi = await _context.EMO_KPI.FindAsync(id);
        if (emoKpi == null)
        {
            return NotFound();
        }

        _context.EMO_KPI.Remove(emoKpi);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EMOKPIExists(string id)
    {
        return _context.EMO_KPI.Any(e => e.Kod == id);
    }
}
