using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU05_KPI_Progress
{
    [Key]
    public long? ProgressID { get; set; }

    [ForeignKey("MOU04_KPI")]
    public long? KPI_ID { get; set; }

    [ForeignKey("MOU01_Memorandum")]
    public string? NoMemo { get; set; }

    public string? Bukti { get; set; }

    public decimal? Amaun { get; set; }

    public decimal? Number { get; set; }

    [NotMapped]
    public bool? isAmount { get; set; }

    public string? Penerangan { get; set; }

    public DateTime? TarikhKemaskini { get; set; }

    [ForeignKey("EMO_Staf")]
    public string? NoStaf { get; set; }

    [JsonIgnore]  // This will prevent the MOU04_KPI reference from being serialized
    public MOU04_KPI? MOU04_KPI { get; set; }  // Navigation property back to MOU04_KPI

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_Staf { get; set; }  // Navigation property back to EMO_Staf
}