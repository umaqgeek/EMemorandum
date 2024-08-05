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
    /// Authenticates a user with the UTeM's SSO and return a unique resource token.
    /// </summary>
    /// <param name="login">The login model containing the email and password.</param>
    /// <returns>A unique resource token if authentication is successful.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<MOU_Status>> GetMOUStatuses()
    {
        return _context.MOU_Statuses.ToList();
    }

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

    [HttpPost]
    public ActionResult<MOU_Status> PostMOUStatus(MOU_Status entity)
    {
        _context.MOU_Statuses.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMOUStatus), new { id = entity.Id }, entity);
    }

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
