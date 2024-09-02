using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class PUU_ScopeMemo
{
    [Key]
    public int? ID { get; set; }
    public int? Kod { get; set; }
    public string? Butiran { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum>? Memorandums { get; set; }
}