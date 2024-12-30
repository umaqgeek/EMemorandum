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
public class PUUScopeMemoController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public PUUScopeMemoController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PUU_ScopeMemo>>> GetPUUScopeMemos()
    {
        return await _context.PUU_ScopeMemo.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PUU_ScopeMemo>> GetPUUScopeMemo(int id)
    {
        var scopeMemo = await _context.PUU_ScopeMemo.FindAsync(id);

        if (scopeMemo == null)
        {
            return NotFound();
        }

        return scopeMemo;
    }

    [HttpPost]
    public async Task<ActionResult<PUU_ScopeMemo>> PostPUUScopeMemo(PUU_ScopeMemo scopeMemo)
    {
        _context.PUU_ScopeMemo.Add(scopeMemo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPUUScopeMemo), new { id = scopeMemo.Kod }, scopeMemo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPUUScopeMemo(int id, PUU_ScopeMemo scopeMemo)
    {
        if (id != scopeMemo.Kod)
        {
            return BadRequest();
        }

        _context.Entry(scopeMemo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PUUScopeMemoExists(id))
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
    public async Task<IActionResult> DeletePUUScopeMemo(int id)
    {
        var scopeMemo = await _context.PUU_ScopeMemo.FindAsync(id);
        if (scopeMemo == null)
        {
            return NotFound();
        }

        _context.PUU_ScopeMemo.Remove(scopeMemo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PUUScopeMemoExists(int id)
    {
        return _context.PUU_ScopeMemo.Any(e => e.Kod == id);
    }
}
