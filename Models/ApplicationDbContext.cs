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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EMO_Roles>()
            .HasOne(r => r.EMO_Staf)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.NoStaf)
            .HasConstraintName("FK_EMO_Roles_EMO_Staf_NoStaf");

        base.OnModelCreating(modelBuilder);
    }
}
