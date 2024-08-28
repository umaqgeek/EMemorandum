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

namespace EMemorandum.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "TokenPolicy")]
    public class MOUController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MOUController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
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

        [HttpGet("{noMemo}")]
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

        private static string TransformToCode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Replace("-", "/");
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
}
