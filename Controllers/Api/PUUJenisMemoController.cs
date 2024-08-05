using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "TokenPolicy")]
public class PUUJenisMemoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PUUJenisMemoController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Jenis Memos
    /// </summary>
    /// <returns>A list of PUU Jenis Memos.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_JenisMemo>> GetPUUJenisMemos()
    {
        return _context.PUU_JenisMemos.ToList();
    }

    /// <summary>
    /// Show a PUU Jenis Memo
    /// </summary>
    /// <param name="id">The id of a PUU Jenis Memo.</param>
    /// <returns>An object of a PUU Jenis Memo.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_JenisMemo> GetPUUJenisMemo(int id)
    {
        var entity = _context.PUU_JenisMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    /// <summary>
    /// Update a PUU Jenis Memo
    /// </summary>
    /// <param name="id">The id of a PUU Jenis Memo.</param>
    /// <param name="entity">The new data for PUU Jenis Memo.</param>
    /// <returns>A new object of a PUU Jenis Memo.</returns>
    [HttpPut("{id}")]
    public ActionResult<PUU_JenisMemo> UpdatePUUJenisMemo(int id, PUU_JenisMemo entity)
    {
        var _entity = _context.PUU_JenisMemos.Find(id);

        if (_entity == null)
        {
            return NotFound();
        }

        if (entity.Kod != null)
        {
            _entity.Kod = entity.Kod;
            _context.Entry(_entity).Property(e => e.Kod).IsModified = true;
        }

        if (entity.Butiran != null)
        {
            _entity.Butiran = entity.Butiran;
            _context.Entry(_entity).Property(e => e.Butiran).IsModified = true;
        }

        if (entity.KodPejabat != null)
        {
            _entity.KodPejabat = entity.KodPejabat;
            _context.Entry(_entity).Property(e => e.KodPejabat).IsModified = true;
        }

        if (entity.Pejabat != null)
        {
            _entity.Pejabat = entity.Pejabat;
            _context.Entry(_entity).Property(e => e.Pejabat).IsModified = true;
        }
        
        _context.SaveChanges();

        return Ok(_entity);
    }

    /// <summary>
    /// Save a PUU Jenis Memo
    /// </summary>
    /// <param name="entity">The new data for PUU Jenis Memo.</param>
    /// <returns>A new object of a PUU Jenis Memo.</returns>
    [HttpPost]
    public ActionResult<PUU_JenisMemo> PostPUUJenisMemo(PUU_JenisMemo entity)
    {
        _context.PUU_JenisMemos.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPUUJenisMemo), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Delete a PUU Jenis Memo
    /// </summary>
    /// <param name="id">The id of a PUU Jenis Memo.</param>
    /// <returns>A status after deleting a PUU Jenis Memo.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_JenisMemo> DeletePUUJenisMemo(int id)
    {
        var entity = _context.PUU_JenisMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        _context.PUU_JenisMemos.Remove(entity);
        _context.SaveChanges();

        return Ok(new { Message = "PUU_JenisMemo deleted successfully" });
    }
}
