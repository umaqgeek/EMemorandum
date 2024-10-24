using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU04_KPI
{
    [Key]
    public long? KPI_ID { get; set; }

    public string? Kod { get; set; }
    public string? NoMemo { get; set; }

    public decimal? Amaun { get; set; }

    public decimal? MOU04_Number { get; set; }

    public string? Penerangan { get; set; }

    public DateTime? TarikhMula { get; set; }

    public DateTime? TarikhTamat { get; set; }

    public string? Komen { get; set; }

    public string? Nama { get; set; }

    public decimal? Nilai { get; set; }

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum
}