using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class ReportController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReportController(IConfiguration configuration, ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("by-category")]
    public ActionResult ByCategory()
    {
        var categories = _context.PUU_KategoriMemo
            .Select(k => new
            {
                Kod = k.Kod,
                Butiran = k.Butiran,
                Count = k.Memorandums.Count(),
            })
            .ToList();
        var labels = categories.Select(x => x.Butiran).ToList();
        var data = categories.Select(x => x.Count).ToList();
        var result = new
        {
            labels = labels,
            data = data,
        };
        return Ok(result);
    }
}