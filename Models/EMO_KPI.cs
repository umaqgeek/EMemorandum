using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class EMO_KPI
{
    [Key]
    public string? Kod { get; set; }
    public string? KPI { get; set; }

    // Navigation property for the MOU04_KPIs
    public ICollection<MOU04_KPI>? MOU04_KPIs { get; set; }
}