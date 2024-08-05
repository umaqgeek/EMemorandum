using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "TokenPolicy")]
public class PUUKategoriMemoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PUUKategoriMemoController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Kategori Memos
    /// </summary>
    /// <returns>A list of PUU Kategori Memos.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_KategoriMemo>> GetPUUKategoriMemos()
    {
        return _context.PUU_KategoriMemos.ToList();
    }

    /// <summary>
    /// Show a PUU Kategori Memo
    /// </summary>
    /// <param name="id">The id of a PUU Kategori Memo.</param>
    /// <returns>An object of a PUU Kategori Memo.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_KategoriMemo> GetPUUKategoriMemo(int id)
    {
        var entity = _context.PUU_KategoriMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    /// <summary>
    /// Update a PUU Kategori Memo
    /// </summary>
    /// <param name="id">The id of a PUU Kategori Memo.</param>
    /// <param name="entity">The new data for PUU Kategori Memo.</param>
    /// <returns>A new object of a PUU Kategori Memo.</returns>
    [HttpPut("{id}")]
    public ActionResult<PUU_KategoriMemo> UpdatePUUKategoriMemo(int id, PUU_KategoriMemo entity)
    {
        var _entity = _context.PUU_KategoriMemos.Find(id);

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
    /// Save a PUU Kategori Memo
    /// </summary>
    /// <param name="entity">The new data for PUU Kategori Memo.</param>
    /// <returns>A new object of a PUU Kategori Memo.</returns>
    [HttpPost]
    public ActionResult<PUU_KategoriMemo> PostPUUKategoriMemo(PUU_KategoriMemo entity)
    {
        _context.PUU_KategoriMemos.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPUUKategoriMemo), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Delete a PUU Kategori Memo
    /// </summary>
    /// <param name="id">The id of a PUU Kategori Memo.</param>
    /// <returns>A status after deleting a PUU Kategori Memo.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_KategoriMemo> DeletePUUKategoriMemo(int id)
    {
        var entity = _context.PUU_KategoriMemos.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        _context.PUU_KategoriMemos.Remove(entity);
        _context.SaveChanges();

        return Ok(new { Message = "PUU_KategoriMemo deleted successfully" });
    }
}
