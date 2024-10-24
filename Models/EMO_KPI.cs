using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class EMO_KPI
{
    [Key]
    public string? Kod { get; set; }
    public string? KPI { get; set; }
}