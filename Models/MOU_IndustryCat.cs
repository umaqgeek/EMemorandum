using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class MOU_IndustryCat
{
    [Key]
    public string? KodInd { get; set; }
    public string? IndustryCategory { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum>? Memorandums { get; set; }
}