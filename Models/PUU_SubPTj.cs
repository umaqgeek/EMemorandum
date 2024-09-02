using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class PUU_SubPTj
{
    [Key]
    public long? ID { get; set; }
    public string? KodPTJ { get; set; }
    public string? KodSubPTJ { get; set; }
    public string? Nama { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum>? Memorandums { get; set; }
}