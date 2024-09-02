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
public class ScopeMemoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ScopeMemoController(IConfiguration configuration, ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Scope Memo
    /// </summary>
    /// <returns>A list of PUU Scope Memo.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_ScopeMemo>> GetAll()
    {
        return _context.PUU_ScopeMemo.ToList();
    }

    /// <summary>
    /// Show a PUU Scope Memo
    /// </summary>
    /// <param name="id">The id of a PUU Scope Memo.</param>
    /// <returns>An object of a PUU Scope Memo.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_ScopeMemo> Get(int id)
    {
        var entity = _context.PUU_ScopeMemo.Find(id);
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
    public ActionResult<PUU_ScopeMemo> Update(int id, [FromBody] PUU_ScopeMemo entity)
    {
        var _entity = _context.PUU_ScopeMemo.Find(id);
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
    public ActionResult<PUU_ScopeMemo> Store([FromBody] PUU_ScopeMemo entity)
    {
        _context.PUU_ScopeMemo.Add(entity);
        _context.SaveChanges();
        return Ok(entity);
    }

    /// <summary>
    /// Delete a PUU Scope Memo
    /// </summary>
    /// <param name="id">The id of a PUU Scope Memo.</param>
    /// <returns>A status after deleting a PUU Scope Memo.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_ScopeMemo> Delete(int id)
    {
        var entity = _context.PUU_ScopeMemo.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        _context.PUU_ScopeMemo.Remove(entity);
        _context.SaveChanges();
        return Ok(new { Message = "Record deleted successfully" });
    }
}
