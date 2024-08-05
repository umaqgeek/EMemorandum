using Microsoft.EntityFrameworkCore;

namespace EMemorandum.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define your DbSets (tables)
    public DbSet<User> Users { get; set; }
    public DbSet<MOU_Status> MOU_Statuses { get; set; }
    public DbSet<PUU_ScopeMemo> PUU_ScopeMemos { get; set; }
    public DbSet<PUU_JenisMemo> PUU_JenisMemos { get; set; }
    public DbSet<PUU_KategoriMemo> PUU_KategoriMemos { get; set; }
}
