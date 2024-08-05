using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "TokenPolicy")]
public class PUUScopeMemoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PUUScopeMemoController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Scope Memos
    /// </summary>
    /// <returns>A list of PUU Scope Memos.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_ScopeMemo>> GetPUUScopeMemos()
    {
        return _context.PUU_ScopeMemos.ToList();
    }

    /// <summary>
    /// Show a PUU Scope Memo
    /// </summary>
    /// <param name="id">The id of a PUU Scope Memo.</param>
    /// <returns>An object of a PUU Scope Memo.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_ScopeMemo> GetPUUScopeMemo(int id)
    {
        var entity = _context.PUU_ScopeMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    /// <summary>
    /// Update a PUU Scope Memo
    /// </summary>
    /// <param name="id">The id of a PUU Scope Memo.</param>
    /// <param name="entity">The new data for PUU Scope Memo.</param>
    /// <returns>A new object of a PUU Scope Memo.</returns>
    [HttpPut("{id}")]
    public ActionResult<PUU_ScopeMemo> UpdatePUUScopeMemo(int id, PUU_ScopeMemo entity)
    {
        var _entity = _context.PUU_ScopeMemos.Find(id);

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
        
        _context.SaveChanges();

        return Ok(_entity);
    }

    /// <summary>
    /// Save a PUU Scope Memo
    /// </summary>
    /// <param name="entity">The new data for PUU Scope Memo.</param>
    /// <returns>A new object of a PUU Scope Memo.</returns>
    [HttpPost]
    public ActionResult<PUU_ScopeMemo> PostPUUScopeMemo(PUU_ScopeMemo entity)
    {
        _context.PUU_ScopeMemos.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPUUScopeMemo), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Delete a PUU Scope Memo
    /// </summary>
    /// <param name="id">The id of a PUU Scope Memo.</param>
    /// <returns>A status after deleting a PUU Scope Memo.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_ScopeMemo> DeletePUUScopeMemo(int id)
    {
        var entity = _context.PUU_ScopeMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        _context.PUU_ScopeMemos.Remove(entity);
        _context.SaveChanges();

        return Ok(new { Message = "PUU_ScopeMemo deleted successfully" });
    }
}
