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
    public DbSet<MOU02_Status> MOU02_Status { get; set; }
    public DbSet<MOU03_Ahli> MOU03_Ahli { get; set; }
    public DbSet<MOU04_KPI> MOU04_KPI { get; set; }
    public DbSet<MOU06_History> MOU06_History { get; set; }

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

        modelBuilder.Entity<MOU02_Status>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU02_Statuses)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(m => m.MOU_Status)
            .WithMany(s => s.Memorandums)
            .HasForeignKey(m => m.Status);

        modelBuilder.Entity<MOU02_Status>()
            .HasOne(m => m.MOU_Status)
            .WithMany(s => s.Statuses)
            .HasForeignKey(m => m.Status);

        modelBuilder.Entity<MOU03_Ahli>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU03_Ahli)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU03_Ahli>()
            .HasKey(m => new { m.NoMemo, m.NoStaf });

        modelBuilder.Entity<MOU04_KPI>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU04_KPI)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU06_History>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU06_History)
            .HasForeignKey(m => m.NoMemo);

        base.OnModelCreating(modelBuilder);
    }

    public string GenerateNextNoMemo(string prefix, int tahun, string kodPTJ)
    {
        // SQL Equivalent:
        // SELECT MAX(CAST(NoSiri AS INT)) AS MaxNoSiri
        // FROM YourTable
        // WHERE Tahun = 2024 AND KodPTJ = '100100';
        var maxNoSiri = MOU01_Memorandum
            .Where(m => m.Tahun == tahun && m.KodPTJ == kodPTJ)
            .AsEnumerable() // Switches to in-memory processing
            .Select(m => int.TryParse(m.NoSiri, out int num) ? num : 0)
            .DefaultIfEmpty(0) // Handle the case where there are no matches
            .Max(); // Get the maximum running number
        // Increment the number to get the next running number
        int nextNumber = maxNoSiri + 1;
        // Format the running number to be zero-padded to 3 digits
        string nextNumberString = nextNumber.ToString("D3");
        // Combine the prefix with the new running number
        return $"{prefix}{nextNumberString}";
    }
}
