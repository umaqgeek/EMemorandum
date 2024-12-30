using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EMemorandum.Models;

public class MOU_AuditLog
{
    [Key]
    public DateTime ID { get; set; }

    [ForeignKey("EMO_Staf")]
    public string? User_ID { get; set; }

    public DateTime? Tarikh_Transaksi { get; set; }
    public string? Proses { get; set; }
    public string? Value { get; set; }
    public string? Nama_Table { get; set; }
    public string? Sub_Menu { get; set; }
    public string? Medan { get; set; }
    public string? Info_Lama { get; set; }

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf? EMO_Staf { get; set; }  // Navigation property back to EMO_Staf
}
