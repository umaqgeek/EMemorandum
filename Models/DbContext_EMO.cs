using Microsoft.EntityFrameworkCore;

namespace EMemorandum.Models;

public class DbContext_EMO : DbContext
{
    public DbContext_EMO(DbContextOptions<DbContext_EMO> options)
        : base(options)
    {
    }

    public DbSet<MOU_AuditLog> MOU_AuditLog { get; set; }
    public DbSet<EMO_Countries> EMO_Countries { get; set; }
    public DbSet<EMO_KPI> EMO_KPI { get; set; }
    public DbSet<EMO_Staf> EMO_Staf { get; set; }
    public DbSet<EMO_Roles> EMO_Roles { get; set; }
    public DbSet<EMO_Roles_Secretariat> EMO_Roles_Secretariat { get; set; }
    public DbSet<EMO_Pejabat> EMO_Pejabat { get; set; }
    public DbSet<MOU_Status> MOU_Status { get; set; }
    public DbSet<PUU_JenisMemo> PUU_JenisMemo { get; set; }
    public DbSet<PUU_KategoriMemo> PUU_KategoriMemo { get; set; }
    public DbSet<PUU_ScopeMemo> PUU_ScopeMemo { get; set; }
    public DbSet<PUU_SubPTj> PUU_SubPTj { get; set; }
    public DbSet<MOU_IndustryCat> MOU_IndustryCat { get; set; }
    public DbSet<MOU_Field> MOU_Field { get; set; }
    public DbSet<MOU_Roles> MOU_Roles { get; set; }
    public DbSet<MOU01_Memorandum> MOU01_Memorandum { get; set; }
    public DbSet<MOU02_Status> MOU02_Status { get; set; }
    public DbSet<MOU03_Ahli> MOU03_Ahli { get; set; }
    public DbSet<MOU04_KPI> MOU04_KPI { get; set; }
    public DbSet<MOU05_KPI_Progress> MOU05_KPI_Progress { get; set; }
    public DbSet<MOU06_History> MOU06_History { get; set; }
    public DbSet<MOU07_Field> MOU07_Field { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EMO_Roles_Secretariat>()
            .HasKey(e => new { e.NoStaf, e.PUU_JenisMemoKod });

        modelBuilder.Entity<EMO_Staf>()
            .HasKey(e => e.NoStaf);

        modelBuilder.Entity<EMO_Roles_Secretariat>()
            .HasOne(r => r.EMO_Staf)
            .WithMany(s => s.EMO_Roles_Secretariats)
            .HasForeignKey(r => r.NoStaf)
            .HasConstraintName("FK_EMO_Roles_Secretariat_EMO_Staf_NoStaf");

        modelBuilder.Entity<EMO_Roles>()
            .HasOne(r => r.EMO_Staf)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.NoStaf)
            .HasConstraintName("FK_EMO_Roles_EMO_Staf_NoStaf");

        modelBuilder.Entity<EMO_Roles>()
            .HasOne(r => r.MOU_Roles)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.Role)
            .HasPrincipalKey(s => s.Code);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.EMO_PejabatPTJ)
            .WithMany(p => p.PTJMemorandums)
            .HasForeignKey(c => c.KodPTJ)
            .HasPrincipalKey(p => p.KodPBU);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.EMO_PejabatSubPTJ)
            .WithMany(p => p.SubPTJMemorandums)
            .HasForeignKey(c => c.KodPTJSub)
            .HasPrincipalKey(p => p.KodPBU);

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
            .HasOne(c => c.EMO_Countries)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.Negara)
            .HasPrincipalKey(p => p.code);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.PUU_KategoriMemo)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodKategori)
            .HasPrincipalKey(p => p.Kod);

        modelBuilder.Entity<MOU_AuditLog>()
            .HasOne(c => c.EMO_Staf)
            .WithMany(p => p.MOU_AuditLogs)
            .HasForeignKey(c => c.User_ID)
            .HasPrincipalKey(p => p.NoStaf);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.EMO_Staf)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.MS01_NoStaf)
            .HasPrincipalKey(p => p.NoStaf);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.EMO_StafAuthor)
            .WithMany(p => p.AuthorMemorandums)
            .HasForeignKey(c => c.Author)
            .HasPrincipalKey(p => p.NoStaf);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.MOU_Status)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.Status)
            .HasPrincipalKey(p => p.Kod);

        modelBuilder.Entity<MOU01_Memorandum>()
            .HasOne(c => c.MOU_IndustryCat)
            .WithMany(p => p.Memorandums)
            .HasForeignKey(c => c.KodInd)
            .HasPrincipalKey(p => p.KodInd);

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

        modelBuilder.Entity<MOU04_KPI>()
            .HasOne(m => m.EMO_KPI)
            .WithMany(s => s.MOU04_KPIs)
            .HasForeignKey(m => m.Kod);

        modelBuilder.Entity<MOU05_KPI_Progress>()
            .HasOne(m => m.MOU04_KPI)
            .WithMany(s => s.MOU05_KPI_Progress)
            .HasForeignKey(m => m.KPI_ID);

        modelBuilder.Entity<MOU05_KPI_Progress>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU05_KPI_Progress)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU06_History>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU06_History)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU07_Field>()
            .HasOne(m => m.MOU01_Memorandum)
            .WithMany(s => s.MOU07_Field)
            .HasForeignKey(m => m.NoMemo);

        modelBuilder.Entity<MOU07_Field>()
            .HasOne(m => m.MOU_Field)
            .WithMany(s => s.MOU07_Fields)
            .HasForeignKey(m => m.KodField);

        modelBuilder.Entity<MOU07_Field>()
            .HasKey(m => new { m.NoMemo, m.KodField });

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
