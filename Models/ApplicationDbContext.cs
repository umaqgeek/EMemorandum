using Microsoft.EntityFrameworkCore;

namespace EMemorandum.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<EMO_Staf> EMO_Staf { get; set; }
    public DbSet<EMO_Roles> EMO_Roles { get; set; }
    public DbSet<MOU_Status> MOU_Statuses { get; set; }
}
