using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class PUU_KategoriMemo
{
    [Key]
    public long? ID { get; set; }
    public int? Kod { get; set; }
    public string? Butiran { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum>? Memorandums { get; set; }
}