using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMemorandum.Models;

namespace EMemorandum.Services;

public class AuditLogService
{
    private readonly DbContext_EMO _context;

    public AuditLogService(DbContext_EMO context)
    {
        _context = context;
    }

    // Add a new audit log entry
    public async Task AddAuditLogAsync(MOU_AuditLog auditLog)
    {
        if (auditLog == null)
        {
            throw new ArgumentNullException(nameof(auditLog));
        }

        await _context.Set<MOU_AuditLog>().AddAsync(auditLog);
        await _context.SaveChangesAsync();
    }

    // Get audit logs based on filters
    public async Task<List<MOU_AuditLog>> GetAuditLogsAsync(string? userId = null, string? process = null, DateTime? from = null, DateTime? to = null)
    {
        var query = _context.Set<MOU_AuditLog>().AsQueryable();

        if (!string.IsNullOrEmpty(userId))
        {
            query = query.Where(log => log.User_ID == userId);
        }

        if (!string.IsNullOrEmpty(process))
        {
            query = query.Where(log => log.Proses == process);
        }

        if (from.HasValue)
        {
            query = query.Where(log => log.Tarikh_Transaksi >= from.Value);
        }

        if (to.HasValue)
        {
            query = query.Where(log => log.Tarikh_Transaksi <= to.Value);
        }

        return await query.ToListAsync();
    }

    // Delete old audit logs (e.g., older than a certain date)
    public async Task DeleteOldAuditLogsAsync(DateTime olderThan)
    {
        var oldLogs = _context.Set<MOU_AuditLog>().Where(log => log.Tarikh_Transaksi < olderThan);
        _context.Set<MOU_AuditLog>().RemoveRange(oldLogs);
        await _context.SaveChangesAsync();
    }
}
