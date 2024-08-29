using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class MOU_Status
{
    [Key]
    public string? Kod { get; set; }
    public string? Status { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum>? Memorandums { get; set; }
}