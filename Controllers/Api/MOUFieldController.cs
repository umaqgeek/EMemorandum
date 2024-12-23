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
public class MOUFieldController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public MOUFieldController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MOU_Field>>> GetMOUFields()
    {
        return await _context.MOU_Field.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MOU_Field>> GetMOUField(string id)
    {
        var mouField = await _context.MOU_Field.FindAsync(id);

        if (mouField == null)
        {
            return NotFound();
        }

        return mouField;
    }

    [HttpPost]
    public async Task<ActionResult<MOU_Field>> PostMOUField(MOU_Field mouField)
    {
        _context.MOU_Field.Add(mouField);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMOUField), new { id = mouField.KodField }, mouField);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMOUField(string id, MOU_Field mouField)
    {
        if (id != mouField.KodField)
        {
            return BadRequest();
        }

        _context.Entry(mouField).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MOUFieldExists(id))
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
    public async Task<IActionResult> DeleteMOUField(string id)
    {
        var mouField = await _context.MOU_Field.FindAsync(id);
        if (mouField == null)
        {
            return NotFound();
        }

        _context.MOU_Field.Remove(mouField);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MOUFieldExists(string id)
    {
        return _context.MOU_Field.Any(e => e.KodField == id);
    }
}
