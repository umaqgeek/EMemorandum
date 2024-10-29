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

    [HttpGet("by-due-a-year")]
    public ActionResult ByDueInAYear()
    {
        var currentDate = DateTime.Now;
        var sixMonthsFromNow = currentDate.AddMonths(6);
        var twelveMonthsFromNow = currentDate.AddMonths(12);
        var dueWithin6Months = _context.MOU01_Memorandum
            .Where(m => m.TarikhTamat <= sixMonthsFromNow)
            .Count();
        var dueWithin6To12Months = _context.MOU01_Memorandum
            .Where(m => m.TarikhTamat > sixMonthsFromNow && m.TarikhTamat <= twelveMonthsFromNow)
            .Count();
        var result = new
        {
            labels = new[] { "Due in 6 months", "Due in 6-12 months" },
            data = new[] { dueWithin6Months, dueWithin6To12Months },
        };
        return Ok(result);
    }

    [HttpGet("by-ptj")]
    public ActionResult ByPTJ()
    {
        var categories = _context.EMO_Pejabat
            .Select(p => new
            {
                KodPBU = p.KodPBU,
                NamaPBU = p.NamaPBU,
                Count = p.PTJMemorandums.Count(),
            })
            .OrderByDescending(p => p.Count)
            .ToList();
        var labels = categories.Select(x => x.NamaPBU).ToList();
        var data = categories.Select(x => x.Count).ToList();
        var result = new
        {
            labels = labels,
            data = data,
        };
        return Ok(result);
    }
}