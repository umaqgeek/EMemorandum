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
            PTJ = _context.EMO_Pejabat.Where(e => e.StatusPTJ == true).ToList(),
            SubPTJ = _context.EMO_Pejabat.ToList(),
            KPIs = _context.EMO_KPI.ToList(),
            Countries = _context.EMO_Countries.Select(c => new
            {
                code = c.code,
                name = c.name,
            }).ToList(),
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

    // TODO: Delete memorandum (PIC, Admin)
    // TODO: Report memo progress
    // TODO: Report memo per category
    // TODO: Report memo per scope
    // TODO: Report memo per type
    // TODO: Report memo dateline

    [HttpPut]
    public ActionResult<object> UpdateMemo([FromBody] MOUAddModel entity)
    {
        var staffId = GetStaffID();

        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var updatedStatus = "02";
        var msg = "has been updated";

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var memo = _context.MOU01_Memorandum
                    .Include(m => m.MOU03_Ahli)
                    .Include(m => m.MOU04_KPI)
                    .FirstOrDefault(m => m.NoMemo == entity.NoMemo);
                if (memo == null) {
                    return NotFound($"Memorandum with number = {entity.NoMemo} not found");
                }

                // update a memo
                memo.KodKategori = entity.form1.KodKategori;
                memo.KodJenis = entity.form1.KodJenis;
                memo.KodPTJ = entity.form1.KodPTJ;
                memo.KodScope = entity.form1.KodScope;
                memo.KodPTJSub = entity.form1.KodPTJSub;
                memo.TarikhMula = entity.form1.TarikhMula;
                memo.TarikhTamat = entity.form1.TarikhTamat;
                memo.TajukProjek = entity.form1.TajukProjek;
                memo.NamaDok = entity.form1.NamaDok;
                memo.Path = entity.form1.Path;
                memo.MS01_NoStaf = entity.form1.MS01_NoStaf;
                memo.Nilai = entity.form1.Nilai;
                memo.Status = updatedStatus;
                memo.Negara = entity.form1.Negara;

                // update a memo's members
                _context.MOU03_Ahli.RemoveRange(memo.MOU03_Ahli);
                foreach (var member in entity.form2.Members) {
                    _context.MOU03_Ahli.Add(new MOU03_Ahli
                    {
                        NoMemo = entity.NoMemo,
                        NoStaf = member.NoStaf,
                        Peranan = member.Peranan,
                        TkhMula = entity.form1.TarikhMula,
                        TkhTamat = entity.form1.TarikhTamat,
                    });
                }

                // update a memo's KPIs
                _context.MOU04_KPI.RemoveRange(memo.MOU04_KPI);
                foreach (var kpi in entity.form3.KPIs)
                {
                    _context.MOU04_KPI.Add(new MOU04_KPI
                    {
                        NoMemo = entity.NoMemo,
                        Amaun = kpi.isAmount == true ? kpi.Amaun : 0,
                        Nilai = kpi.isAmount == false ? kpi.Amaun : 0,
                        MOU04_Number = kpi.MOU04_Number,
                        Penerangan = kpi.Penerangan,
                        TarikhMula = kpi.TarikhMula,
                        TarikhTamat = kpi.TarikhTamat,
                        Komen = kpi.Komen,
                        Nama = kpi.Nama,
                        Kod = kpi.Kod,
                    });
                }

                var mouStatus = new MOU02_Status
                {
                    NoMemo = entity.NoMemo,
                    Status = updatedStatus,
                    Tarikh = DateTime.Now,
                };
                _context.MOU02_Status.Add(mouStatus);

                var history = new MOU06_History
                {
                    NoMemo = entity.NoMemo,
                    Description = $"Memorandum {msg}",
                    Created_At = DateTime.Now,
                    NoStaf = staffId,
                };
                _context.MOU06_History.Add(history);

                // Save changes to the database
                _context.SaveChanges();
                // Commit the transaction if all commands succeed
                transaction.Commit();

                // TODO: Still sending emails to previous members even already been removed
                // send emails to all viewers (pic, members, author) of this memo after all transaction is done
                sendEmailsAfterUpdate("Memorandum Updated", entity.NoMemo, msg);
            }
            catch (Exception ex)
            {
                // Rollback the transaction if any command fails
                transaction.Rollback();
                // Log or rethrow the exception as needed
                throw;
            }
        }

        return Ok(new { NoMemo = entity.NoMemo });
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
            Author = staffId,
            Negara = entity.form1.Negara,
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
                        Amaun = kpi.isAmount == true ? kpi.Amaun : 0,
                        Nilai = kpi.isAmount == false ? kpi.Amaun : 0,
                        MOU04_Number = kpi.MOU04_Number,
                        Penerangan = kpi.Penerangan,
                        TarikhMula = kpi.TarikhMula,
                        TarikhTamat = kpi.TarikhTamat,
                        Komen = kpi.Komen,
                        Nama = kpi.Nama,
                        Kod = kpi.Kod,
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

    [HttpPost("approval")]
    [Authorize(Policy = "PTJPolicy")]
    public ActionResult<object> ApprovalRejectionMemorandum([FromBody] ApprovalModel entity)
    {
        var staffId = GetStaffID();

        var statusMsg = "has been reviewed";
        switch (entity.Status) {
            case "03":
                statusMsg = "has been approved";
                break;
            case "04":
                statusMsg = "has been sent back to the PIC";
                break;
            case "05":
                statusMsg = "has been rejected";
                break;
            default:
                return NotFound(new { Error = "Status not found" });
        }

        var mouHistory = new MOU06_History
        {
            NoMemo = entity.NoMemo,
            NoStaf = staffId,
            Description = $"Memorandum {statusMsg}",
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

                // send emails to all viewers (pic, members, author) of this memo after all transaction is done
                sendEmailsAfterUpdate("1 New Comment", entity.NoMemo, statusMsg);
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

                // Save changes to the database
                _context.SaveChanges();
                // Commit the transaction if all commands succeed
                transaction.Commit();

                // send emails to all viewers (pic, members, author) of this memo after all transaction is done
                sendEmailsAfterUpdate("1 New Comment", entity.NoMemo, "has been commented");
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
            .Include(_entity => _entity.EMO_PejabatPTJ)
            .Include(_entity => _entity.EMO_PejabatSubPTJ)
            .Include(_entity => _entity.PUU_JenisMemo)
            .Include(_entity => _entity.PUU_KategoriMemo)
            .Include(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.EMO_StafAuthor)
            .Include(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.MOU06_History)
                .ThenInclude(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU03_Ahli)
                .ThenInclude(_entity => _entity.EMO_Staf)
                    .ThenInclude(_entity => _entity.Roles)
            .Include(_entity => _entity.MOU04_KPI)
                .ThenInclude(_entity => _entity.EMO_KPI)
            .Include(_entity => _entity.EMO_Countries)
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
        var ptj = _context.EMO_Pejabat
            .Where(j => j.KodPejPBU == entity.KodPTJ)
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
            PTJNama = _entity.EMO_PejabatPTJ.NamaPBU,
            KodScope = _entity.KodScope,
            ScopeButiran = _entity.PUU_ScopeMemo.Butiran,
            KodJenis = _entity.KodJenis,
            Jenis = _entity.PUU_JenisMemo.Butiran,
            KodKategori = _entity.KodKategori,
            Kategori = _entity.PUU_KategoriMemo.Butiran,
            KodPTJSub = _entity.KodPTJSub,
            SubPTJNama = _entity.EMO_PejabatSubPTJ.NamaPBU,
            TarikhMula = _entity.TarikhMula,
            TarikhMulaDate = GetDisplayDate(_entity.TarikhMula),
            TarikhMulaDate2 = GetDisplayDate2(_entity.TarikhMula),
            TarikhTamat = _entity.TarikhTamat,
            TarikhTamatDate = GetDisplayDate(_entity.TarikhTamat),
            TarikhTamatDate2 = GetDisplayDate2(_entity.TarikhTamat),
            TajukProjek = _entity.TajukProjek,
            Path = _entity.Path,
            NamaDok = _entity.NamaDok,
            IsPIC = _entity.MS01_NoStaf == staffId,
            PIC = _entity.EMO_Staf.Nama,
            PICGelaran = _entity.EMO_Staf.Gelaran,
            PICEmail = _entity.EMO_Staf.Email,
            noStafPIC = _entity.EMO_Staf.NoStaf,
            Author = _entity.EMO_StafAuthor.Nama,
            AuthorGelaran = _entity.EMO_StafAuthor.Gelaran,
            AuthorEmail = _entity.EMO_StafAuthor.Email,
            AuthorNoStaf = _entity.EMO_StafAuthor.NoStaf,
            Nilai = _entity.Nilai,
            Negara = new
            {
                _entity.EMO_Countries.code,
                _entity.EMO_Countries.name,
            },
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
                Kod = mou04.Kod,
                Kpi = mou04.EMO_KPI.KPI,
                Amaun = mou04.Amaun,
                Nilai = mou04.Nilai,
                Komen = mou04.Komen,
                Nama = mou04.Nama,
                Penerangan = mou04.Penerangan,
                TarikhMula = mou04.TarikhMula,
                TarikhMulaDate = mou04.TarikhMula?.ToString("dd MMM yyyy") ?? "",
                TarikhMulaDate2 = mou04.TarikhMula?.ToString("yyyy-MM-dd") ?? "",
                TarikhTamat = mou04.TarikhTamat,
                TarikhTamatDate = mou04.TarikhTamat?.ToString("dd MMM yyyy") ?? "",
                TarikhTamatDate2 = mou04.TarikhTamat?.ToString("yyyy-MM-dd") ?? "",
            })?.ToList(),
        });
    }

    private static string GetDisplayDate(DateTime? nullableDateTime)
    {
        DateTime dateTime = nullableDateTime ?? DateTime.MinValue;
        return dateTime.ToString("dd/MM/yyyy");
    }

    private static string GetDisplayDate2(DateTime? nullableDateTime)
    {
        DateTime dateTime = nullableDateTime ?? DateTime.MinValue;
        return dateTime.ToString("yyyy-MM-dd");
    }

    private IQueryable<MOU01_Memorandum> GetMemorandumBaseQuery(string q)
    {
        var query = _context.MOU01_Memorandum
            .Include(_entity => _entity.MOU02_Statuses)
                .ThenInclude(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.PUU_ScopeMemo)
            .Include(_entity => _entity.EMO_PejabatPTJ)
            .Include(_entity => _entity.EMO_PejabatSubPTJ)
            .Include(_entity => _entity.PUU_JenisMemo)
            .Include(_entity => _entity.PUU_KategoriMemo)
            .Include(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.EMO_StafAuthor)
            .Include(_entity => _entity.MOU_Status)
            .Include(_entity => _entity.MOU06_History)
                .ThenInclude(_entity => _entity.EMO_Staf)
            .Include(_entity => _entity.MOU03_Ahli)
                .ThenInclude(_entity => _entity.EMO_Staf)
                    .ThenInclude(_entity => _entity.Roles)
            .Include(_entity => _entity.MOU04_KPI)
                .ThenInclude(_entity => _entity.EMO_KPI)
            .Include(_entity => _entity.EMO_Countries)
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

    private void sendEmailsAfterUpdate(string subject, string noMemo, string statusMsg)
    {
        var staffId = GetStaffID();

        var memo = _context.MOU01_Memorandum.FirstOrDefault(m => m.NoMemo == noMemo);

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
            var gelaran = staff.Gelaran.Contains("TIADA DILAPORKAN", StringComparison.OrdinalIgnoreCase) ? "" : staff.Gelaran;
            var body = $"<p>{gelaran} {staff.Nama}</p><p>Memorandum with Memo ID "
                + $"<strong>{memo.NoMemo}</strong> {statusMsg}. Please click this link "
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
    }

    private void SyncMembers(MOU01_Memorandum existingMOU, ICollection<MOU03_Ahli> updatedMembers)
    {
        // Convert the current members into a dictionary for easy lookup
        var existingMembers = existingMOU.MOU03_Ahli.ToDictionary(m => m.NoMemo);

        // Step 1: Update or Add new members
        foreach (var updatedMember in updatedMembers)
        {
            if (existingMembers.TryGetValue(updatedMember.NoStaf, out var existingMember))
            {
                existingMember.NoStaf = updatedMember.NoStaf;
                existingMember.Peranan = updatedMember.Peranan;
            }
            else
            {
                existingMOU.MOU03_Ahli.Add(new MOU03_Ahli
                {
                    NoMemo = existingMOU.NoMemo,
                    NoStaf = updatedMember.NoStaf,
                    Peranan = updatedMember.Peranan,
                    TkhMula = existingMOU.TarikhMula,
                    TkhTamat = existingMOU.TarikhTamat,
                });
            }
        }

        // Step 2: Remove members that are not in the updated set
        var updatedMemberIds = updatedMembers.Select(m => m.NoStaf).ToHashSet();
        var membersToRemove = existingMOU.MOU03_Ahli.Where(m => !updatedMemberIds.Contains(m.NoStaf)).ToList();
        foreach (var member in membersToRemove)
        {
            _context.MOU03_Ahli.Remove(member);
        }
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
    public string? NoMemo { get; set; }
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