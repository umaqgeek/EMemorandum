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
public class MOUIndustryCatController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public MOUIndustryCatController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MOU_IndustryCat>>> GetMOUIndustryCats()
    {
        return await _context.MOU_IndustryCat.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MOU_IndustryCat>> GetMOUIndustryCat(string id)
    {
        var mouIndustryCat = await _context.MOU_IndustryCat.FindAsync(id);

        if (mouIndustryCat == null)
        {
            return NotFound();
        }

        return mouIndustryCat;
    }

    [HttpPost]
    public async Task<ActionResult<MOU_IndustryCat>> PostMOUIndustryCat(MOU_IndustryCat mouIndustryCat)
    {
        _context.MOU_IndustryCat.Add(mouIndustryCat);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMOUIndustryCat), new { id = mouIndustryCat.KodInd }, mouIndustryCat);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMOUIndustryCat(string id, MOU_IndustryCat mouIndustryCat)
    {
        if (id != mouIndustryCat.KodInd)
        {
            return BadRequest();
        }

        _context.Entry(mouIndustryCat).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MOUIndustryCatExists(id))
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
    public async Task<IActionResult> DeleteMOUIndustryCat(string id)
    {
        var mouIndustryCat = await _context.MOU_IndustryCat.FindAsync(id);
        if (mouIndustryCat == null)
        {
            return NotFound();
        }

        _context.MOU_IndustryCat.Remove(mouIndustryCat);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MOUIndustryCatExists(string id)
    {
        return _context.MOU_IndustryCat.Any(e => e.KodInd == id);
    }
}
