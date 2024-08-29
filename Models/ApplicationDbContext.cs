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
    public DbSet<MOU_Status> MOU_Status { get; set; }
    public DbSet<PUU_JenisMemo> PUU_JenisMemo { get; set; }
    public DbSet<PUU_KategoriMemo> PUU_KategoriMemo { get; set; }
    public DbSet<PUU_ScopeMemo> PUU_ScopeMemo { get; set; }
    public DbSet<PUU_SubPTj> PUU_SubPTj { get; set; }
    public DbSet<MOU01_Memorandum> MOU01_Memorandum { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EMO_Roles>()
            .HasOne(r => r.EMO_Staf)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.NoStaf)
            .HasConstraintName("FK_EMO_Roles_EMO_Staf_NoStaf");

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.PUU_SubPTj)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodPTJ)
            .HasPrincipalKey(p => p.KodPTJ);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.PUU_ScopeMemo)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodScope)
            .HasPrincipalKey(p => p.Kod);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.PUU_JenisMemo)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodJenis)
            .HasPrincipalKey(p => p.Kod);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.PUU_KategoriMemo)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodKategori)
            .HasPrincipalKey(p => p.Kod);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.EMO_Staf)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.MS01_NoStaf)
            .HasPrincipalKey(p => p.NoStaf);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.MOU_Status)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.Status)
            .HasPrincipalKey(p => p.Kod);

        base.OnModelCreating(modelBuilder);
    }
}
