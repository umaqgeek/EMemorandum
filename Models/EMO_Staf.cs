using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMemorandum.Models;

[Table("VEMO_Staf", Schema = "dbo")]
public class EMO_Staf
{
    [Key]
    public string NoStaf { get; set; }
    public string Nama { get; set; }
    public string? NoTelBimbit { get; set; }
    public string? Email { get; set; }
    public string? NJawatan { get; set; }
    public string? JGiliran { get; set; }
    public string? KodPejabat { get; set; }
    // public string? KodPTJSub { get; set; }
    public string? NPejabat { get; set; }
    // public string? Singkat { get; set; }
    // public string? MS01_KpB { get; set; }
    public string? Gelaran { get; set; }
    public string? MS01_Jantina { get; set; }
    public string? Warganegara { get; set; }

    // Navigation property for the roles
    public ICollection<EMO_Roles> Roles { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum> Memorandums { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum> AuthorMemorandums { get; set; }

    // Navigation property for the mou03_ahli
    public ICollection<MOU03_Ahli> Members { get; set; }

    // Navigation property for the mou06_history
    public ICollection<MOU06_History> Histories { get; set; }

    // Navigation property for the mou06_history
    public ICollection<EMO_Roles_Secretariat> EMO_Roles_Secretariats { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU_AuditLog> MOU_AuditLogs { get; set; }
}