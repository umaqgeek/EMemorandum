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
public class PUUKategoriMemoController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public PUUKategoriMemoController(DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PUU_KategoriMemo>>> GetPUUKategoriMemos()
    {
        return await _context.PUU_KategoriMemo.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PUU_KategoriMemo>> GetPUUKategoriMemo(int id)
    {
        var kategoriMemo = await _context.PUU_KategoriMemo.FindAsync(id);

        if (kategoriMemo == null)
        {
            return NotFound();
        }

        return kategoriMemo;
    }

    [HttpPost]
    public async Task<ActionResult<PUU_KategoriMemo>> PostPUUKategoriMemo(PUU_KategoriMemo kategoriMemo)
    {
        _context.PUU_KategoriMemo.Add(kategoriMemo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPUUKategoriMemo), new { id = kategoriMemo.Kod }, kategoriMemo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPUUKategoriMemo(int id, PUU_KategoriMemo kategoriMemo)
    {
        if (id != kategoriMemo.Kod)
        {
            return BadRequest();
        }

        _context.Entry(kategoriMemo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PUUKategoriMemoExists(id))
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
    public async Task<IActionResult> DeletePUUKategoriMemo(int id)
    {
        var kategoriMemo = await _context.PUU_KategoriMemo.FindAsync(id);
        if (kategoriMemo == null)
        {
            return NotFound();
        }

        _context.PUU_KategoriMemo.Remove(kategoriMemo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PUUKategoriMemoExists(int id)
    {
        return _context.PUU_KategoriMemo.Any(e => e.Kod == id);
    }
}
