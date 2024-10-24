using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class EMO_Pejabat
{
    [Key]
    public string? KodPBU { get; set; }
    public string? KodPejPBU { get; set; }
    public string? Pejabat { get; set; }
    public string? NamaPBU { get; set; }
    public bool? StatusPTJ { get; set; }
}