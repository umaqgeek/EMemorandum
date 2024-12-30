using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MOU_AuditLog
{
    [Key]
    public DateTime ID { get; set; }
    public string? User_ID { get; set; }
    public DateTime? Tarikh_Transaksi { get; set; }
    public string? Proses { get; set; }
    public string? Value { get; set; }
    public string? Nama_Table { get; set; }
    public string? Sub_Menu { get; set; }
    public string? Medan { get; set; }
    public string? Info_Lama { get; set; }
}
