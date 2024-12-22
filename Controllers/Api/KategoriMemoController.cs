using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
[Authorize(Policy = "AdminOrPUUPolicy")]
public class KategoriMemoController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public KategoriMemoController(IConfiguration configuration, DbContext_EMO context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Kategori Memo
    /// </summary>
    /// <returns>A list of PUU Kategori Memo.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_KategoriMemo>> GetAll()
    {
        return _context.PUU_KategoriMemo.ToList();
    }

    /// <summary>
    /// Show a PUU Kategori Memo
    /// </summary>
    /// <param name="id">The id of a PUU Kategori Memo.</param>
    /// <returns>An object of a PUU Kategori Memo.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_KategoriMemo> Get(long id)
    {
        var entity = _context.PUU_KategoriMemo.Find(id);
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
    public ActionResult<PUU_KategoriMemo> Update(long id, [FromBody] PUU_KategoriMemo entity)
    {
        var _entity = _context.PUU_KategoriMemo.Find(id);
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
    public ActionResult<PUU_KategoriMemo> Store([FromBody] PUU_KategoriMemo entity)
    {
        _context.PUU_KategoriMemo.Add(entity);
        _context.SaveChanges();
        return Ok(entity);
    }

    /// <summary>
    /// Delete a PUU Kategori Memo
    /// </summary>
    /// <param name="id">The id of a PUU Kategori Memo.</param>
    /// <returns>A status after deleting a PUU Kategori Memo.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_KategoriMemo> Delete(long id)
    {
        var entity = _context.PUU_KategoriMemo.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        _context.PUU_KategoriMemo.Remove(entity);
        _context.SaveChanges();
        return Ok(new { Message = "Record deleted successfully" });
    }
}