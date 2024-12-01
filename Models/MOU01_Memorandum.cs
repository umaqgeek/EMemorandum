using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU01_Memorandum
{
    [Key]
    public string? NoMemo { get; set; }
    public string? NoSiri { get; set; }
    public int? Tahun { get; set; }

    [ForeignKey("EMO_Pejabat")]
    public string KodPTJ { get; set; }

    [ForeignKey("PUU_ScopeMemo")]
    public int KodScope { get; set; }

    [ForeignKey("PUU_JenisMemo")]
    public int KodJenis { get; set; }

    [ForeignKey("PUU_KategoriMemo")]
    public int KodKategori { get; set; }

    [ForeignKey("EMO_Pejabat")]
    public string? KodPTJSub { get; set; }

    public DateTime? TarikhMula { get; set; }
    public DateTime? TarikhTamat { get; set; }
    public string? TajukProjek { get; set; }
    public string? NamaDok { get; set; }
    public string? Path { get; set; }

    [ForeignKey("EMO_StafAuthor")]
    public string? Author { get; set; }

    [ForeignKey("EMO_Countries")]
    public string? Negara { get; set; }

    [ForeignKey("EMO_Staf")]
    public string? MS01_NoStaf { get; set; }

    [ForeignKey("MOU_Status")]
    public string? Status { get; set; }

    [ForeignKey("MOU_IndustryCat")]
    public string? KodInd { get; set; }

    public decimal? Nilai { get; set; }

    [JsonIgnore]  // This will prevent the EMO_Countries reference from being serialized
    public EMO_Countries? EMO_Countries { get; set; }  // Navigation property back to EMO_Countries

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_Staf { get; set; }  // Navigation property back to EMO_Staf

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_StafAuthor { get; set; }  // Navigation property back to EMO_Staf

    [JsonIgnore]  // This will prevent the PUU_ScopeMemo reference from being serialized
    public PUU_ScopeMemo? PUU_ScopeMemo { get; set; }  // Navigation property back to PUU_ScopeMemo

    [JsonIgnore]  // This will prevent the PUU_JenisMemo reference from being serialized
    public PUU_JenisMemo? PUU_JenisMemo { get; set; }  // Navigation property back to PUU_JenisMemo

    [JsonIgnore]  // This will prevent the PUU_KategoriMemo reference from being serialized
    public PUU_KategoriMemo? PUU_KategoriMemo { get; set; }  // Navigation property back to PUU_KategoriMemo

    [JsonIgnore]  // This will prevent the EMO_Pejabat reference from being serialized
    public EMO_Pejabat? EMO_PejabatPTJ { get; set; }  // Navigation property back to EMO_Pejabat

    [JsonIgnore]  // This will prevent the EMO_Pejabat reference from being serialized
    public EMO_Pejabat? EMO_PejabatSubPTJ { get; set; }  // Navigation property back to EMO_Pejabat

    [JsonIgnore]  // This will prevent the MOU_Status reference from being serialized
    public MOU_Status? MOU_Status { get; set; }  // Navigation property back to MOU_Status

    [JsonIgnore]  // This will prevent the MOU_IndustryCat reference from being serialized
    public MOU_IndustryCat? MOU_IndustryCat { get; set; }  // Navigation property back to MOU_IndustryCat

    // Navigation property for the statuses
    public ICollection<MOU02_Status>? MOU02_Statuses { get; set; }

    // Navigation property for the members
    public ICollection<MOU03_Ahli>? MOU03_Ahli { get; set; }

    // Navigation property for the kpi
    public ICollection<MOU04_KPI>? MOU04_KPI { get; set; }

    // Navigation property for the kpi progress
    public ICollection<MOU05_KPI_Progress>? MOU05_KPI_Progress { get; set; }

    // Navigation property for the history
    public ICollection<MOU06_History>? MOU06_History { get; set; }
}