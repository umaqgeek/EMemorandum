using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult<User> GetUser(int id)
    {
        var entity = _context.Users.Find(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    [HttpPost]
    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult<User> PostUser(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUser), new { id = entity.Id }, entity);
    }
}
