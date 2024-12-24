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
public class PUUJenisMemoController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public PUUJenisMemoController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PUU_JenisMemo>>> GetPUUJenisMemos()
    {
        return await _context.PUU_JenisMemo.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PUU_JenisMemo>> GetPUUJenisMemo(int id)
    {
        var jenisMemo = await _context.PUU_JenisMemo.FindAsync(id);

        if (jenisMemo == null)
        {
            return NotFound();
        }

        return jenisMemo;
    }

    [HttpPost]
    public async Task<ActionResult<PUU_JenisMemo>> PostPUUJenisMemo(PUU_JenisMemo jenisMemo)
    {
        _context.PUU_JenisMemo.Add(jenisMemo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPUUJenisMemo), new { id = jenisMemo.Kod }, jenisMemo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPUUJenisMemo(int id, PUU_JenisMemo jenisMemo)
    {
        if (id != jenisMemo.Kod)
        {
            return BadRequest();
        }

        _context.Entry(jenisMemo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PUUJenisMemoExists(id))
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
    public async Task<IActionResult> DeletePUUJenisMemo(int id)
    {
        var jenisMemo = await _context.PUU_JenisMemo.FindAsync(id);
        if (jenisMemo == null)
        {
            return NotFound();
        }

        _context.PUU_JenisMemo.Remove(jenisMemo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PUUJenisMemoExists(int id)
    {
        return _context.PUU_JenisMemo.Any(e => e.Kod == id);
    }
}
