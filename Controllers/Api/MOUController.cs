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
using EMemorandum.Services;
using EMemorandum.Jobs;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class MOUController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly string _delimeter;
    private readonly IConfiguration _configuration;
    private readonly IEmailQueueService _emailQueueService;

    public MOUController(IConfiguration configuration, ApplicationDbContext context, IEmailQueueService emailQueueService)
    {
        _context = context;
        _delimeter = ".";
        _configuration = configuration;
        _emailQueueService = emailQueueService;
    }

    [HttpGet("all")]
    [Authorize(Policy = "AdminOrPUUOrPTJPolicy")]
    public ActionResult<IEnumerable<object>> GetAllMemorandums([FromQuery] string? q)
    {
        var staffId = GetStaffID();

        var query = GetMemorandumBaseQuery(q);

        var memorandums = query
            .Select(_entity => GetTransformedMOU(_entity, staffId))
            .ToList();

        return Ok(memorandums);
    }

    [HttpGet("mine")]
    public ActionResult<IEnumerable<object>> GetAllMemorandumsForAStaff([FromQuery] string? q)
    {
        var staffId = GetStaffID();

        var query = GetMemorandumBaseQuery(q);

        var memorandums = query
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
        });
    }

    [HttpPost("generate-no")]
    public ActionResult<object> GenerateNo([FromBody] MemorandumGenNo entity)
    {
        var genNo = getGeneratedNo(entity);
        if (genNo != null && genNo.GetType().GetProperty("error") != null)
        {
            return NotFound(genNo);
        }
        return Ok(genNo);
    }

    [HttpPost]
    public ActionResult<object> Store([FromBody] MOUAddModel entity)
    {
        var staffId = GetStaffID();

        var genNo = getGeneratedNo(new MemorandumGenNo
        {
            KodJenis = entity.form1.KodJenis,
            KodKategori = entity.form1.KodKategori,
            KodPTJ = entity.form1.KodPTJ,
        });
        if (genNo != null && genNo.GetType().GetProperty("error") != null)
        {
            return NotFound(genNo);
        }

        var initialStatus = "01";
        var noSiris = genNo.noMemo.Split(".");
        var noSiri = "";
        if (noSiris.Length > 0)
        {
            noSiri = noSiris[noSiris.Length - 1];
        }
        var mou = new MOU01_Memorandum
        {
            NoMemo = genNo.noMemo,
            NoSiri = noSiri,
            Tahun = DateTime.Now.Year,
            KodPTJ = entity.form1.KodPTJ,
            KodScope = entity.form1.KodScope,
            KodJenis = entity.form1.KodJenis,
            KodKategori = entity.form1.KodKategori,
            KodPTJSub = entity.form1.KodPTJSub,
            TarikhMula = entity.form1.TarikhMula,
            TarikhTamat = entity.form1.TarikhTamat,
            TajukProjek = entity.form1.TajukProjek,
            NamaDok = entity.form1.NamaDok,
            Path = entity.form1.Path,
            MS01_NoStaf = entity.form1.MS01_NoStaf,
            Status = initialStatus,
            Nilai = entity.form1.Nilai,
        };

        var mouStatus = new MOU02_Status
        {
            NoMemo = genNo.noMemo,
            Status = initialStatus,
            Tarikh = DateTime.Now,
        };

        var history = new MOU06_History
        {
            NoMemo = genNo.noMemo,
            Description = "Memorandum has been created",
            Created_At = DateTime.Now,
            NoStaf = staffId,
        };

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                // add MOU
                _context.MOU01_Memorandum.Add(mou);

                // add initial status for added MOU
                _context.MOU02_Status.Add(mouStatus);

                // add history
                _context.MOU06_History.Add(history);

                // add members for added MOU
                List<string> noStafList = new List<string>();
                foreach (var member in entity.form2.Members)
                {
                    _context.MOU03_Ahli.Add(new MOU03_Ahli
                    {
                        NoMemo = genNo.noMemo,
                        NoStaf = member.NoStaf,
                        Peranan = member.Peranan,
                        TkhMula = entity.form1.TarikhMula,
                        TkhTamat = entity.form1.TarikhTamat,
                    });
                    noStafList.Add(member.NoStaf);
                }

                // add KPIs for added MOU
                foreach (var kpi in entity.form3.KPIs)
                {
                    _context.MOU04_KPI.Add(new MOU04_KPI
                    {
                        NoMemo = genNo.noMemo,
                        Amaun = kpi.Amaun,
                        MOU04_Number = kpi.MOU04_Number,
                        Penerangan = kpi.Penerangan,
                        TarikhMula = kpi.TarikhMula,
                        TarikhTamat = kpi.TarikhTamat,
                        Komen = kpi.Komen,
                        Nama = kpi.Nama,
                    });
                }

                // get emails of MOU's members
                var staffs = _context.EMO_Staf
                    .Where(s => noStafList.Contains(s.NoStaf) && !string.IsNullOrEmpty(s.Email))
                    .ToList();

                // Trigger sending emails in the background
                foreach (var staff in staffs)
                {
                    var EMOURL = _configuration.GetValue<string>("EMOURL");
                    var subject = "Member of a Memorandum";
                    var gelaran = staff.Gelaran.Contains("TIADA DILAPORKAN", StringComparison.OrdinalIgnoreCase) ? "" : staff.Gelaran;
                    var body = $"<p>{gelaran} {staff.Nama}</p><p>You have been added as a member of a memorandum with Memo ID "
                        + $"<strong>{genNo.noMemo}</strong>. Please click this link "
                        + $"<a target='_blank' href='{EMOURL}?UsrLogin={staff.NoStaf}&callback=memo-detail?memo={genNo.noMemo}'>{EMOURL}memo-detail?memo={genNo.noMemo}</a>"
                        + " for more info.</p>";
                    var emailJob = new EmailJob
                    {
                        Email = staff.Email,
                        Subject = subject,
                        Body = body,
                    };
                    _emailQueueService.QueueEmailJob(emailJob);
                }

                // Save changes to the database
                _context.SaveChanges();
                // Commit the transaction if all commands succeed
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any command fails
                transaction.Rollback();
                // Log or rethrow the exception as needed
                throw;
            }
        }

        return Ok(genNo);
    }

    // TODO: Update memorandum (PIC, Admin)
    // TODO: Delete memorandum (PIC, Admin)
    // TODO: Add members to a memorandum (PIC, Admin)
    // TODO: Add KPIs to a memorandum (PIC, Admin)

    [HttpPost("approval")]
    [Authorize(Policy = "PTJPolicy")]
    public ActionResult<object> ApprovalRejectionMemorandum([FromBody] ApprovalModel entity)
    {
        var staffId = GetStaffID();

        var msgDesc = "Memorandum has been reviewed";
        switch (entity.Status) {
            case "03":
                msgDesc = "Memorandum has been approved";
                break;
            case "04":
                msgDesc = "Memorandum has been sent back to the PIC";
                break;
            case "05":
                msgDesc = "Memorandum has been rejected";
                break;
            default:
                return NotFound(new { Error = "Status not found" });
        }

        var mouHistory = new MOU06_History
        {
            NoMemo = entity.NoMemo,
            NoStaf = staffId,
            Description = msgDesc,
            Created_At = DateTime.Now,
            Comment = entity.Comment,
        };

        var mouStatus = new MOU02_Status
        {
            NoMemo = entity.NoMemo,
            Status = entity.Status,
            Tarikh = DateTime.Now,
        };

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var memo = _context.MOU01_Memorandum.FirstOrDefault(m => m.NoMemo == entity.NoMemo);
                if (memo == null) {
                    return NotFound();
                }
                memo.Status = entity.Status;

                // Save comments and add new history
                _context.MOU06_History.Add(mouHistory);

                // add new status for existing MOU
                _context.MOU02_Status.Add(mouStatus);

                // Save changes to the database
                _context.SaveChanges();
                // Commit the transaction if all commands succeed
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any command fails
                transaction.Rollback();
                // Log or rethrow the exception as needed
                throw;
            }
        }

        return Ok(new { Status = true });
    }

    [HttpPost("comment")]
    public ActionResult<object> CommentMemorandum([FromBody] MOU06_History entity)
    {
        var staffId = GetStaffID();

        var mouHistory = new MOU06_History
        {
            NoMemo = entity.NoMemo,
            NoStaf = staffId,
            Description = "Memorandum has been reviewed",
            Created_At = DateTime.Now,
            Comment = entity.Comment,
        };

        var statusReviewed = "02";
        var mouStatus = new MOU02_Status
        {
            NoMemo = entity.NoMemo,
            Status = statusReviewed,
            Tarikh = DateTime.Now,
        };

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var memo = _context.MOU01_Memorandum.FirstOrDefault(m => m.NoMemo == entity.NoMemo);
                if (memo == null) {
                    return NotFound();
                }
                memo.Status = statusReviewed;

                // Save comments and add new history
                _context.MOU06_History.Add(mouHistory);

                // add new status for existing MOU
                _context.MOU02_Status.Add(mouStatus);

                // email to all members and pic of this memo
                List<string> noStafList = new List<string>();
                if (staffId != memo.MS01_NoStaf) {
                    noStafList.Add(memo.MS01_NoStaf);
                }
                var members = _context.MOU03_Ahli.Select(mou03 => new MOU03_Ahli
                    {
                        NoStaf = mou03.NoStaf,
                    })?
                    .Where(mou03 => mou03.NoStaf != staffId)?
                    .ToList();
                foreach (var member in members)
                {
                    noStafList.Add(member.NoStaf);
                }
                var staffs = _context.EMO_Staf
                    .Where(s => noStafList.Contains(s.NoStaf) && !string.IsNullOrEmpty(s.Email))
                    .ToList();
                foreach (var staff in staffs)
                {
                    var EMOURL = _configuration.GetValue<string>("EMOURL");
                    var subject = "1 New Comment";
                    var gelaran = staff.Gelaran.Contains("TIADA DILAPORKAN", StringComparison.OrdinalIgnoreCase) ? "" : staff.Gelaran;
                    var body = $"<p>{gelaran} {staff.Nama}</p><p>Memorandum with Memo ID "
                        + $"<strong>{memo.NoMemo}</strong> has been commented. Please click this link "
                        + $"<a target='_blank' href='{EMOURL}?UsrLogin={staff.NoStaf}&callback=memo-detail?memo={memo.NoMemo}'>{EMOURL}memo-detail?memo={memo.NoMemo}</a>"
                        + " for more info.</p>";
                    var emailJob = new EmailJob
                    {
                        Email = staff.Email,
                        Subject = subject,
                        Body = body,
                    };
                    _emailQueueService.QueueEmailJob(emailJob);
                }

                // Save changes to the database
                _context.SaveChanges();
                // Commit the transaction if all commands succeed
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any command fails
                transaction.Rollback();
                // Log or rethrow the exception as needed
                throw;
            }
        }

        return Ok(new { Status = true });
    }

    [HttpGet("get/{noMemo}")]
    public ActionResult<MOU01_Memorandum> GetMemorandum(string noMemo)
    {
        var staffId = GetStaffID();

        var _entity = _context.MOU01_Memorandum
            .Where(m => m.NoMemo == noMemo)
            .Include(_entity => _entity.MOU02_Statuses)
                .ThenInclude(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.PUU_ScopeMemo)
            .Include(_entity => _entity.PUU_SubPTj)
            .Include(_entity => _entity.PUU_JenisMemo)
            .Include(_entity => _entity.PUU_KategoriMemo)
            .Include(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.MOU06_History)
                .ThenInclude(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU03_Ahli)
                .ThenInclude(_entity => _entity.EMO_Staf)
                    .ThenInclude(_entity => _entity.Roles)
            .Include(_entity => _entity.MOU04_KPI)
            .FirstOrDefault();

        if (_entity == null)
        {
            return NotFound();
        }

        return Ok(GetTransformedMOU(_entity, staffId));
    }

    private dynamic getGeneratedNo(MemorandumGenNo entity)
    {
        // Sample:
        // MoA(P).1.2.2024.101010.001
        // kategori.kodkategori.kodjenis.currentyear.kodptj.runningnumber
        var kategori = _context.PUU_KategoriMemo
            .Where(k => k.Kod == entity.KodKategori)
            .FirstOrDefault();
        if (kategori == null)
        {
            return (new { error = "KodKategori not found!" });
        }
        var jenis = _context.PUU_JenisMemo
            .Where(j => j.Kod == entity.KodJenis)
            .FirstOrDefault();
        if (jenis == null)
        {
            return (new { error = "KodJenis not found!" });
        }
        var ptj = _context.PUU_SubPTj
            .Where(j => j.KodPTJ == entity.KodPTJ)
            .FirstOrDefault();
        if (ptj == null)
        {
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
            PTJNama = _entity.PUU_SubPTj.Nama,
            KodScope = _entity.KodScope,
            ScopeButiran = _entity.PUU_ScopeMemo.Butiran,
            KodJenis = _entity.KodJenis,
            Jenis = _entity.PUU_JenisMemo.Butiran,
            KodKategori = _entity.KodKategori,
            Kategori = _entity.PUU_KategoriMemo.Butiran,
            KodPTJSub = _entity.KodPTJSub,
            TarikhMula = _entity.TarikhMula,
            TarikhMulaDate = GetDisplayDate(_entity.TarikhMula),
            TarikhTamat = _entity.TarikhTamat,
            TarikhTamatDate = GetDisplayDate(_entity.TarikhTamat),
            TajukProjek = _entity.TajukProjek,
            Path = _entity.Path,
            IsPIC = _entity.MS01_NoStaf == staffId,
            PIC = _entity.EMO_Staf.Nama,
            PICGelaran = _entity.EMO_Staf.Gelaran,
            noStafPIC = _entity.EMO_Staf.NoStaf,
            Nilai = _entity.Nilai,
            Status = new
            {
                _entity.MOU_Status.Kod,
                _entity.MOU_Status.Status,
            },
            Statuses = _entity.MOU02_Statuses.Select(mou02 => new
            {
                Status_ID = mou02.Status_ID,
                NoMemo = mou02.NoMemo,
                Tarikh = mou02.Tarikh,
                StatusInner = new
                {
                    mou02.MOU_Status.Kod,
                    mou02.MOU_Status.Status
                },
            })?.OrderByDescending(_entity => _entity.Tarikh).ToList(),
            History = _entity.MOU06_History.Select(mou06 => new
            {
                Created_At = mou06.Created_At?.ToString("dd MMM yyyy, h:mm tt") ?? "",
                Ori_Created_At = mou06.Created_At,
                Description = mou06.Description,
                Comment = mou06.Comment,
                NoStaf = mou06.NoStaf,
                Gelaran = mou06.EMO_Staf.Gelaran,
                Nama = mou06.EMO_Staf.Nama,
            })?.OrderByDescending(_entity => _entity.Ori_Created_At).ToList(),
            Members = _entity.MOU03_Ahli.Select(mou03 => new
            {
                Peranan = mou03.Peranan,
                Email = mou03.EMO_Staf.Email,
                Gelaran = mou03.EMO_Staf.Gelaran,
                Nama = mou03.EMO_Staf.Nama,
                NoStaf = mou03.EMO_Staf.NoStaf,
                Roles = mou03.EMO_Staf.Roles,
            })?.ToList(),
            KPIs = _entity.MOU04_KPI.Select(mou04 => new
            {
                Amaun = mou04.Amaun,
                Komen = mou04.Komen,
                Nama = mou04.Nama,
                Penerangan = mou04.Penerangan,
                TarikhMula = mou04.TarikhMula,
                TarikhMulaDate = mou04.TarikhMula?.ToString("dd MMM yyyy") ?? "",
                TarikhTamat = mou04.TarikhTamat,
                TarikhTamatDate = mou04.TarikhTamat?.ToString("dd MMM yyyy") ?? "",
            })?.ToList(),
        });
    }

    private static string GetDisplayDate(DateTime? nullableDateTime)
    {
        DateTime dateTime = nullableDateTime ?? DateTime.MinValue;
        return dateTime.ToString("dd/MM/yyyy");
    }

    private IQueryable<MOU01_Memorandum> GetMemorandumBaseQuery(string q)
    {
        var query = _context.MOU01_Memorandum
            .Include(_entity => _entity.MOU02_Statuses)
                .ThenInclude(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.PUU_ScopeMemo)
            .Include(_entity => _entity.PUU_SubPTj)
            .Include(_entity => _entity.PUU_JenisMemo)
            .Include(_entity => _entity.PUU_KategoriMemo)
            .Include(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.MOU06_History)
                .ThenInclude(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU03_Ahli)
                .ThenInclude(_entity => _entity.EMO_Staf)
                    .ThenInclude(_entity => _entity.Roles)
            .Include(_entity => _entity.MOU04_KPI)
            .AsQueryable();

        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(_entity =>
                _entity.NoMemo.ToLower().Contains(q.ToLower()) ||
                _entity.TajukProjek.ToLower().Contains(q.ToLower()) ||
                _entity.PUU_ScopeMemo.Butiran.ToLower().Contains(q.ToLower()) ||
                _entity.PUU_JenisMemo.Butiran.ToLower().Contains(q.ToLower()) ||
                _entity.MOU02_Statuses.Any(s => s.Status.ToLower().Contains(q.ToLower())) ||
                _entity.EMO_Staf.Nama.ToLower().Contains(q.ToLower())
            );
        }

        // sort by ascending
        query = query.OrderBy(_entity => _entity.Status);

        // default limit of 500 rows per query
        query = query.Take(500);

        return query;
    }
}

public class MemorandumGenNo
{
    public int KodKategori { get; set; }
    public int KodJenis { get; set; }
    public string KodPTJ { get; set; }
}

public class MOUAddModel
{
    public MOU01_Memorandum form1 { get; set; }
    public MOUMembers form2 { get; set; }
    public MOUKPIs form3 { get; set; }
}

public class MOUMembers
{
    public ICollection<MOU03_Ahli> Members { get; set; }
}

public class MOUKPIs
{
    public ICollection<MOU04_KPI> KPIs { get; set; }
}

public class ApprovalModel
{
    public string NoMemo { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }
}