using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU06_History
{
    [Key]
    public long? id { get; set; }

    [ForeignKey("MOU01_Memorandum")]
    public string? NoMemo { get; set; }

    [ForeignKey("EMO_Staf")]
    public string? NoStaf { get; set; }

    public string? Description { get; set; }

    public DateTime? Created_At { get; set; }

    public string? Comment { get; set; }

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_Staf { get; set; }  // Navigation property back to EMO_Staf
}