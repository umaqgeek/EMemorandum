using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "TokenPolicy")]
public class MOUStatusController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MOUStatusController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// List all MOU Statuses
    /// </summary>
    /// <returns>A list of MOU Statuses.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<MOU_Status>> GetMOUStatuses()
    {
        return _context.MOU_Statuses.ToList();
    }

    /// <summary>
    /// Show a MOU Status
    /// </summary>
    /// <param name="id">The id of a MOU Status.</param>
    /// <returns>An object of a MOU Status.</returns>
    [HttpGet("{id}")]
    public ActionResult<MOU_Status> GetMOUStatus(int id)
    {
        var entity = _context.MOU_Statuses.Find(id);

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
    public ActionResult<MOU_Status> UpdateMOUStatus(int id, MOU_Status entity)
    {
        var _entity = _context.MOU_Statuses.Find(id);

        if (_entity == null)
        {
            return NotFound();
        }

        if (entity.Kod != null)
        {
            _entity.Kod = entity.Kod;
            _context.Entry(_entity).Property(e => e.Kod).IsModified = true;
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
    public ActionResult<MOU_Status> PostMOUStatus(MOU_Status entity)
    {
        _context.MOU_Statuses.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMOUStatus), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Delete a MOU Status
    /// </summary>
    /// <param name="id">The id of a MOU Status.</param>
    /// <returns>A status after deleting a MOU Status.</returns>
    [HttpDelete("{id}")]
    public ActionResult<MOU_Status> DeleteMOUStatus(int id)
    {
        var entity = _context.MOU_Statuses.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        _context.MOU_Statuses.Remove(entity);
        _context.SaveChanges();

        return Ok(new { Message = "MOU_Status deleted successfully" });
    }
}
