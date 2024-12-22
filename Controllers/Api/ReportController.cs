using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    private readonly DbContext_EMO _context;

    public ReportController(IConfiguration configuration, DbContext_EMO context)
    {
        _context = context;
    }

    [HttpGet("dashboard")]
    public ActionResult Dashboard()
    {
        var mouCount = _context.MOU01_Memorandum.Count();
        var mouNewCount = _context.MOU01_Memorandum.Where(m => m.Status == "00" || m.Status == "01").Count();
        var mouPendingCount = _context.MOU01_Memorandum.Where(m => m.Status == "03").Count();
        var staffCount = _context.EMO_Staf.Where(r => r.Roles.Any() && r.Roles != null).Count();
        var dashboard = new
        {
            mou = mouCount,
            mouNew = mouNewCount,
            mouPending = mouPendingCount,
            staff = staffCount,
        };
        return Ok(dashboard);
    }

    [HttpGet("by-category")]
    public ActionResult ByCategory()
    {
        var categories = _context.PUU_KategoriMemo
            // .Where(k => k.Memorandums.Count() > 0)
            .Select(k => new
            {
                Kod = k.Kod,
                name = k.Butiran,
                value = k.Memorandums.Count(),
            })
            .OrderByDescending(k => k.value)
            .ToList();
        return Ok(categories);
    }

    [HttpGet("by-country-map")]
    public ActionResult ByCountryMap()
    {
        var countries = _context.EMO_Countries
            .Include(k => k.Memorandums)
            .Where(k => k.Memorandums != null && k.Memorandums.Count() > 0)
            .Select(k => new
            {
                name = k.name,
                value = k.Memorandums.Count(),
            })
            .ToList();
        return Ok(countries);
    }

    [HttpGet("by-country")]
    public ActionResult ByCountry()
    {
        var countries = _context.EMO_Countries
            .Where(k => k.Memorandums.Count() > 0)
            .Select(k => new
            {
                Code = k.code,
                Name = k.name,
                Count = k.Memorandums.Count(),
            })
            .ToList();
        var labels = countries.Select(x => x.Name).ToList();
        var data = countries.Select(x => x.Count).ToList();
        var result = new
        {
            labels = labels,
            data = data,
        };
        return Ok(result);
    }

    [HttpGet("by-status")]
    public ActionResult ByStatus()
    {
        var statuses = _context.MOU_Status
            // .Where(k => k.Memorandums.Count() > 0)
            .Select(k => new
            {
                Kod = k.Kod,
                name = k.Status,
                value = k.Memorandums.Count(),
            })
            .ToList();
        // var labels = statuses.Select(x => x.Status).ToList();
        // var data = statuses.Select(x => x.Count).ToList();
        // var result = new
        // {
        //     labels = labels,
        //     data = data,
        // };
        return Ok(statuses);
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
        // var result = new
        // {
        //     labels = new[] { "Due in 6 months", "Due in 6-12 months" },
        //     data = new[] { dueWithin6Months, dueWithin6To12Months },
        // };
        var result = new[]
        {
            new
            {
                name = "Due in 6 months",
                value = dueWithin6Months,
            },
            new
            {
                name = "Due in 6-12 months",
                value = dueWithin6To12Months,
            }
        };
        return Ok(result);
    }

    [HttpGet("by-ptj")]
    public ActionResult ByPTJ()
    {
        var categories = _context.EMO_Pejabat
            .Where(k => k.PTJMemorandums.Count() > 0)
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