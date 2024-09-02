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

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class MOUController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly string _delimeter;

    public MOUController(IConfiguration configuration, ApplicationDbContext context)
    {
        _context = context;
        _delimeter = ".";
    }

    [HttpGet("all")]
    [Authorize(Policy = "AdminOrPUUPolicy")]
    public ActionResult<IEnumerable<object>> GetAllMemorandums()
    {
        var staffId = GetStaffID();

        var memorandums = _context.MOU01_Memorandum
            .Select(_entity => GetTransformedMOU(_entity, staffId))
            .ToList();

        return Ok(memorandums);
    }

    [HttpGet("mine")]
    public ActionResult<IEnumerable<object>> GetAllMemorandumsForAStaff()
    {
        var staffId = GetStaffID();

        var memorandums = _context.MOU01_Memorandum
            .Where(m => m.MS01_NoStaf == staffId)
            .Select(_entity => GetTransformedMOU(_entity, staffId))
            .ToList();

        return Ok(memorandums);
    }

    [HttpGet("select-data")]
    public ActionResult<IEnumerable<object>> GetSelectData()
    {
        return Ok(new
        {
            JenisMemo = _context.PUU_JenisMemo.ToList(),
            KategoriMemo = _context.PUU_KategoriMemo.ToList(),
            ScopeMemo = _context.PUU_ScopeMemo.ToList(),
            SubPTJ = _context.PUU_SubPTj.ToList(),
            // TODO: List all staff for memo's members
        });
    }

    [HttpPost("generate-no")]
    public ActionResult<object> GenerateNo([FromBody] MemorandumGenNo entity)
    {
        var genNo = getGeneratedNo(entity);
        if (genNo != null && genNo.GetType().GetProperty("error") != null) {
            return NotFound(genNo);
        }
        return Ok(genNo);
    }

    // TODO: Add memorandum and its members and its KPIs (All)
    [HttpPost]
    public ActionResult<string> Store([FromBody] MOU01_Memorandum entity)
    {
        var genNo = getGeneratedNo(new MemorandumGenNo
        {
            KodJenis = entity.KodJenis,
            KodKategori = entity.KodKategori,
            KodPTJ = entity.KodPTJ,
        });
        if (genNo != null && genNo.GetType().GetProperty("error") != null) {
            return NotFound(genNo);
        }
        return Ok(genNo);
    }

    // TODO: Update memorandum (PIC, Admin)
    // TODO: Delete memorandum (PIC, Admin)
    // TODO: Add members to a memorandum (PIC, Admin)
    // TODO: Add KPIs to a memorandum (PIC, Admin)
    // TODO: Review and comment a memorandum (PUU)
    // TODO: Approve or reject a memorandum (PTJ)

    [HttpGet("get/{noMemo}")]
    public ActionResult<MOU01_Memorandum> GetMemorandum(string noMemo)
    {
        var staffId = GetStaffID();

        var _entity = _context.MOU01_Memorandum
            .Where(m => m.NoMemo == noMemo)
            .FirstOrDefault();

        if (_entity == null)
        {
            return NotFound();
        }

        return Ok(GetTransformedMOU(_entity, staffId));
    }

    private object getGeneratedNo(MemorandumGenNo entity)
    {
        // Sample:
        // MoA(P).1.2.2024.101010.001
        // kategori.kodkategori.kodjenis.currentyear.kodptj.runningnumber
        var kategori = _context.PUU_KategoriMemo
            .Where(k => k.Kod == entity.KodKategori)
            .FirstOrDefault();
        if (kategori == null) {
            return (new { error = "KodKategori not found!" });
        }
        var jenis = _context.PUU_JenisMemo
            .Where(j => j.Kod == entity.KodJenis)
            .FirstOrDefault();
        if (jenis == null) {
            return (new { error = "KodJenis not found!" });
        }
        var ptj = _context.PUU_SubPTj
            .Where(j => j.KodPTJ == entity.KodPTJ)
            .FirstOrDefault();
        if (ptj == null) {
            return (new { error = "KodPTJ not found!" });
        }
        var currentYear = DateTime.Now.Year;
        var prefix = kategori.Butiran + _delimeter +
            kategori.Kod + _delimeter +
            jenis.Kod + _delimeter +
            currentYear + _delimeter +
            entity.KodPTJ + _delimeter;
        return (new { noMemo = _context.GenerateNextNoMemo(prefix, currentYear, entity.KodPTJ) });
    }

    private static string TransformToCode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        return input.Replace("-", ".");
    }

    private string GetStaffID()
    {
        // Fetch the token from the Authorization header
        var authHeader = Request.Headers["Authorization"].FirstOrDefault();
        if (authHeader != null && authHeader.StartsWith("Bearer "))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }
        return null;
    }

    private static object GetTransformedMOU(MOU01_Memorandum _entity, string staffId)
    {
        return (new
        {
            NoMemo = TransformToCode(_entity.NoMemo),
            NoSiri = _entity.NoSiri,
            Tahun = _entity.Tahun,
            KodPTJ = _entity.KodPTJ,
            KodScope = _entity.KodScope,
            KodJenis = _entity.KodJenis,
            KodKategori = _entity.KodKategori,
            KodPTJSub = _entity.KodPTJSub,
            TarikhMula = _entity.TarikhMula,
            TarikhTamat = _entity.TarikhTamat,
            TajukProjek = _entity.TajukProjek,
            IsPIC = _entity.MS01_NoStaf == staffId,
            Nilai = _entity.Nilai,
        });
    }
}

public class MemorandumGenNo
{
    public int KodKategori { get; set; }
    public int KodJenis { get; set; }
    public string KodPTJ { get; set; }
}