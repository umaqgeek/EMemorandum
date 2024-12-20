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

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrPUUPolicy")]
public class StatusController : ControllerBase
{
    private readonly DbContext_EMO _context;

    public StatusController(DbContext_EMO context)
    {
        _context = context;
    }

    /// <summary>
    /// List all MOU Statuses
    /// </summary>
    /// <returns>A list of MOU Statuses.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<MOU_Status>> GetAll()
    {
        return _context.MOU_Status.ToList();
    }

    /// <summary>
    /// Show a MOU Status
    /// </summary>
    /// <param name="id">The id of a MOU Status.</param>
    /// <returns>An object of a MOU Status.</returns>
    [HttpGet("{id}")]
    public ActionResult<MOU_Status> Get(string id)
    {
        var entity = _context.MOU_Status.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        return entity;
    }

    /// <summary>
    /// Update a MOU Status
    /// </summary>
    /// <param name="id">The id of a MOU Status.</param>
    /// <param name="entity">The new data for MOU Status.</param>
    /// <returns>A new object of a MOU Status.</returns>
    [HttpPut("{id}")]
    public ActionResult<MOU_Status> Update(string id, [FromBody] MOU_Status entity)
    {
        var _entity = _context.MOU_Status.Find(id);
        if (_entity == null)
        {
            return NotFound();
        }
        if (entity.Status != null)
        {
            _entity.Status = entity.Status;
            _context.Entry(_entity).Property(e => e.Status).IsModified = true;
        }
        _context.SaveChanges();
        return Ok(_entity);
    }

    /// <summary>
    /// Save a MOU Status
    /// </summary>
    /// <param name="entity">The new data for MOU Status.</param>
    /// <returns>A new object of a MOU Status.</returns>
    [HttpPost]
    public ActionResult<MOU_Status> Store([FromBody] MOU_Status entity)
    {
        _context.MOU_Status.Add(entity);
        _context.SaveChanges();
        return Ok(entity);
    }

    /// <summary>
    /// Delete a MOU Status
    /// </summary>
    /// <param name="id">The id of a MOU Status.</param>
    /// <returns>A status after deleting a MOU Status.</returns>
    [HttpDelete("{id}")]
    public ActionResult<MOU_Status> Delete(string id)
    {
        var entity = _context.MOU_Status.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        _context.MOU_Status.Remove(entity);
        _context.SaveChanges();
        return Ok(new { Message = "Record deleted successfully" });
    }
}