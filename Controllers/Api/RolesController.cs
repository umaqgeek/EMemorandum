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
[Authorize(Policy = "AdminPolicy")]
public class RolesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RolesController(IConfiguration configuration, ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAllRoles()
    {
        var roles = _context.MOU_Roles
            .Where(r => r.Code != "Staff")
            .Select(r => new
            {
                Code = r.Code,
                Role = r.Role,
            })
            .ToList();;
        return Ok(roles);
    }
}
