using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class EMO_Roles_Secretariat
{
    [Key, Column(Order = 0)]
    [ForeignKey("EMO_Staf")]
    public string? NoStaf { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("PUU_JenisMemo")]
    public int? PUU_JenisMemoKod { get; set; }

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf EMO_Staf { get; set; }  // Navigation property back to EMO_Staf

    [JsonIgnore]  // This will prevent the PUU_JenisMemo reference from being serialized
    public PUU_JenisMemo PUU_JenisMemo { get; set; }  // Navigation property back to PUU_JenisMemo
}