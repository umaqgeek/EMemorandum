using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU03_Ahli
{
    [Key, Column(Order = 0)]
    [StringLength(50)]
    public string? NoMemo { get; set; }

    [Key, Column(Order = 1)]
    [StringLength(5)]
    public string NoStaf { get; set; }

    [StringLength(250)]
    public string? Peranan { get; set; }

    public DateTime? TkhMula { get; set; }

    public DateTime? TkhTamat { get; set; }

    public string? Status { get; set; }

    public string? SuratLantikan { get; set; }

    public string? Path { get; set; }

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_Staf { get; set; }  // Navigation property back to EMO_Staf
}