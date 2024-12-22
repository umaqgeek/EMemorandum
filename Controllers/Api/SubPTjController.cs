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
public class SubPTjController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public SubPTjController(IConfiguration configuration, DbContext_EMO context)
    {
        _context = context;
    }

    /// <summary>
    /// List all PUU Sub PTj
    /// </summary>
    /// <returns>A list of PUU Sub PTj.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PUU_SubPTj>> GetAll()
    {
        return _context.PUU_SubPTj.ToList();
    }

    /// <summary>
    /// Show a PUU Sub PTj
    /// </summary>
    /// <param name="id">The id of a PUU Sub PTj.</param>
    /// <returns>An object of a PUU Sub PTj.</returns>
    [HttpGet("{id}")]
    public ActionResult<PUU_SubPTj> Get(long id)
    {
        var entity = _context.PUU_SubPTj.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        return entity;
    }

    /// <summary>
    /// Update a PUU Sub PTj
    /// </summary>
    /// <param name="id">The id of a PUU Sub PTj.</param>
    /// <param name="entity">The new data for PUU Sub PTj.</param>
    /// <returns>A new object of a PUU Sub PTj.</returns>
    [HttpPut("{id}")]
    public ActionResult<PUU_SubPTj> Update(long id, [FromBody] PUU_SubPTj entity)
    {
        var _entity = _context.PUU_SubPTj.Find(id);
        if (_entity == null)
        {
            return NotFound();
        }
        if (entity.KodPTJ != null)
        {
            _entity.KodPTJ = entity.KodPTJ;
            _context.Entry(_entity).Property(e => e.KodPTJ).IsModified = true;
        }
        if (entity.KodSubPTJ != null)
        {
            _entity.KodSubPTJ = entity.KodSubPTJ;
            _context.Entry(_entity).Property(e => e.KodSubPTJ).IsModified = true;
        }
        if (entity.Nama != null)
        {
            _entity.Nama = entity.Nama;
            _context.Entry(_entity).Property(e => e.Nama).IsModified = true;
        }
        _context.SaveChanges();
        return Ok(_entity);
    }

    /// <summary>
    /// Save a PUU Sub PTj
    /// </summary>
    /// <param name="entity">The new data for PUU Sub PTj.</param>
    /// <returns>A new object of a PUU Sub PTj.</returns>
    [HttpPost]
    public ActionResult<PUU_SubPTj> Store([FromBody] PUU_SubPTj entity)
    {
        _context.PUU_SubPTj.Add(entity);
        _context.SaveChanges();
        return Ok(entity);
    }

    /// <summary>
    /// Delete a PUU Sub PTj
    /// </summary>
    /// <param name="id">The id of a PUU Sub PTj.</param>
    /// <returns>A status after deleting a PUU Sub PTj.</returns>
    [HttpDelete("{id}")]
    public ActionResult<PUU_SubPTj> Delete(long id)
    {
        var entity = _context.PUU_SubPTj.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        _context.PUU_SubPTj.Remove(entity);
        _context.SaveChanges();
        return Ok(new { Message = "Record deleted successfully" });
    }
}