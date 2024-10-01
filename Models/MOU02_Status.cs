using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU02_Status
{
    [Key]
    public int? Status_ID { get; set; }

    [ForeignKey("MOU01_Memorandum")]
    public string? NoMemo { get; set; }

    [ForeignKey("MOU_Status")]
    public string Status { get; set; }

    public DateTime? Tarikh { get; set; }

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum

    [JsonIgnore]  // This will prevent the MOU_Status reference from being serialized
    public MOU_Status? MOU_Status { get; set; }  // Navigation property back to MOU_Status
}