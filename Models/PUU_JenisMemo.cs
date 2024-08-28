using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class PUU_JenisMemo
{
    [Key]
    public long ID { get; set; }
    public int Kod { get; set; }
    public string Butiran { get; set; }
    public string? KodPejabat { get; set; }
    public string? Pejabat { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum> Memorandums { get; set; }
}