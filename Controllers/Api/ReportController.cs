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

    [HttpGet("details")]
    public ActionResult<IEnumerable<DetailsItemDto>> GetDetailsData(
        [FromQuery] string? country = null,
        [FromQuery] string? industry = null,
        [FromQuery] string? ptj = null,
        [FromQuery] int? category = null,
        [FromQuery] int? type = null
    )
    {
        // Fetch raw data from the database
        var query = _context.MOU01_Memorandum
            .Include(m => m.MOU_IndustryCat)
            .Include(m => m.EMO_PejabatPTJ)
            .Include(m => m.EMO_Staf)
            .Include(m => m.PUU_KategoriMemo)
            .Include(m => m.PUU_JenisMemo)
            .Include(m => m.EMO_Countries)
            .Include(m => m.MOU05_KPI_Progress)
            .AsQueryable(); // Use IQueryable to allow further filtering

        if (!string.IsNullOrEmpty(country)) {
            query = query.Where(m => m.EMO_Countries != null && m.EMO_Countries.code == country);
        }
        if (!string.IsNullOrEmpty(industry)) {
            query = query.Where(m => m.MOU_IndustryCat != null && m.MOU_IndustryCat.KodInd == industry);
        }
        if (!string.IsNullOrEmpty(ptj)) {
            query = query.Where(m => m.EMO_PejabatPTJ != null && m.EMO_PejabatPTJ.KodPBU == ptj);
        }
        if (category.HasValue) {
            query = query.Where(m => m.PUU_KategoriMemo != null && m.PUU_KategoriMemo.Kod == category);
        }
        if (type.HasValue) {
            query = query.Where(m => m.PUU_JenisMemo != null && m.PUU_JenisMemo.Kod == type);
        }

        // Materialize data into memory
        var rawData = query.ToList();

        // Transform data in memory
        var detailsData = rawData.Select((m, index) => new DetailsItemDto
        {
            No = index + 1,
            Country = new
            {
                code = m.EMO_Countries?.code,
                name = m.EMO_Countries?.name,
            },
            IndustryCategory = new
            {
                KodInd = m.MOU_IndustryCat?.KodInd,
                IndustryCategory = m.MOU_IndustryCat?.IndustryCategory,
            },
            FacultyPTJ = m.EMO_PejabatPTJ?.NamaPBU ?? "N/A",
            PIC = m.EMO_Staf?.Nama ?? "N/A",
            PICGelaran = m.EMO_Staf?.Gelaran ?? "",
            Category = m.PUU_KategoriMemo?.Butiran ?? "N/A",
            Type = m.PUU_JenisMemo?.Butiran ?? "N/A",
            StartDate = GetDisplayDate(m.TarikhMula),
            EndDate = GetDisplayDate(m.TarikhTamat),
            Duration = m.TarikhMula.HasValue && m.TarikhTamat.HasValue
                ? GetDuration(m.TarikhMula.Value, m.TarikhTamat.Value)
                : "N/A",
            Status = m.MOU05_KPI_Progress != null && m.MOU05_KPI_Progress.Count() > 0 ? "ACTIVE" : "NO PROGRESS"
        });

        return Ok(detailsData);
    }

    [HttpGet("dashboard")]
    public ActionResult Dashboard()
    {
        var mouCount = _context.MOU01_Memorandum.Where(m => m.Status != "07").Count();
        // var mouNewCount = _context.MOU01_Memorandum.Where(m => m.Status == "00" || m.Status == "01").Count();
        // var mouPendingCount = _context.MOU01_Memorandum.Where(m => m.Status == "03").Count();
        // var staffCount = _context.EMO_Staf.Where(r => r.Roles.Any() && r.Roles != null).Count();
        var currentDate = DateTime.Now;
        var sixMonthsFromNow = currentDate.AddMonths(6);
        var dueWithin6Months = _context.MOU01_Memorandum
            .Where(m => m.Status != "07")
            .Where(m => m.TarikhTamat <= sixMonthsFromNow)
            .Count();
        var mouActive = _context.MOU01_Memorandum
            .Include(m => m.MOU05_KPI_Progress)
            .Where(k => k.MOU05_KPI_Progress != null && k.MOU05_KPI_Progress.Count() > 0)
            .Count();
        var mouNotActive = _context.MOU01_Memorandum
            .Include(m => m.MOU05_KPI_Progress)
            .Where(k => k.MOU05_KPI_Progress == null || k.MOU05_KPI_Progress.Count() <= 0)
            .Count();
        var dashboard = new
        {
            mou = mouCount,
            // mouNew = mouNewCount,
            // mouPending = mouPendingCount,
            // staff = staffCount,
            dueWithin6Months = dueWithin6Months,
            mouActive = mouActive,
            mouNotActive = mouNotActive,
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
                value = k.Memorandums.Where(m => m.Status != "07").Count(),
            })
            .OrderByDescending(k => k.value)
            .ToList();
        var labels = categories.Select(x => x.name).ToList();
        var data = categories.Select(x => x.value).ToList();
        var result = new
        {
            labels = labels,
            data = data,
        };
        return Ok(result);
    }

    [HttpGet("by-country-map")]
    public ActionResult ByCountryMap()
    {
        var countries = _context.EMO_Countries
            .Include(k => k.Memorandums)
            .Where(k => k.Memorandums != null && k.Memorandums.Where(m => m.Status != "07").Count() > 0)
            .Select(k => new
            {
                name = k.name,
                value = k.Memorandums.Where(m => m.Status != "07").Count(),
            })
            .ToList();
        return Ok(countries);
    }

    [HttpGet("by-country")]
    public ActionResult ByCountry()
    {
        var countries = _context.EMO_Countries
            .Where(k => k.Memorandums.Where(m => m.Status != "07").Count() > 0)
            .Select(k => new
            {
                Code = k.code,
                Name = k.name,
                Count = k.Memorandums.Where(m => m.Status != "07").Count(),
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
                value = k.Memorandums.Where(m => m.Status != "07").Count(),
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
            .Where(m => m.Status != "07")
            .Where(m => m.TarikhTamat <= sixMonthsFromNow)
            .Count();
        var dueWithin6To12Months = _context.MOU01_Memorandum
            .Where(m => m.Status != "07")
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
            .Where(k => k.PTJMemorandums.Where(m => m.Status != "07").Count() > 0)
            .Select(p => new
            {
                KodPBU = p.KodPBU,
                name = p.NamaPBU,
                value = p.PTJMemorandums.Where(m => m.Status != "07").Count(),
            })
            .OrderByDescending(p => p.value)
            .ToList();
        // var labels = categories.Select(x => x.NamaPBU).ToList();
        // var data = categories.Select(x => x.Count).ToList();
        // var result = new
        // {
        //     labels = labels,
        //     data = data,
        // };
        return Ok(categories);
    }

    private string GetDuration(DateTime startDate, DateTime endDate)
    {
        var duration = endDate - startDate;
        if (duration.Days >= 365)
            return $"{duration.Days / 365} YEAR(S)";
        if (duration.Days >= 30)
            return $"{duration.Days / 30} MONTH(S)";
        return $"{duration.Days} DAY(S)";
    }

    private static string GetDisplayDate(DateTime? nullableDateTime)
    {
        DateTime dateTime = nullableDateTime ?? DateTime.MinValue;
        return dateTime.ToString("dd/MM/yyyy");
    }
}

public class DetailsItemDto
{
    public int No { get; set; }
    public object Country { get; set; }
    public object IndustryCategory { get; set; }
    public string FacultyPTJ { get; set; }
    public string PIC { get; set; }
    public string PICGelaran { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Duration { get; set; }
    public string Status { get; set; }
}
