using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class EMO_Roles
{
    public long id { get; set; }

    [ForeignKey("EMO_Staf")]
    public string NoStaf { get; set; }

    [ForeignKey("MOU_Roles")]
    public string Role { get; set; }

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf EMO_Staf { get; set; }  // Navigation property back to EMO_Staf

    [JsonIgnore]  // This will prevent the MOU_Roles reference from being serialized
    public MOU_Roles MOU_Roles { get; set; }  // Navigation property back to MOU_Roles
}