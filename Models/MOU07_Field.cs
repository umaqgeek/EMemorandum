using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU07_Field
{
    [Key, Column(Order = 0)]
    [ForeignKey("MOU01_Memorandum")]
    public string? NoMemo { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("MOU_Field")]
    public string? KodField { get; set; }

    [JsonIgnore]  // This will prevent the MOU01_Memorandum reference from being serialized
    public MOU01_Memorandum? MOU01_Memorandum { get; set; }  // Navigation property back to MOU01_Memorandum

    [JsonIgnore]  // This will prevent the MOU_Field reference from being serialized
    public MOU_Field? MOU_Field { get; set; }  // Navigation property back to MOU_Field
}