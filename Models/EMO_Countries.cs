using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class EMO_Countries
{
    [Key]
    public string? code { get; set; }
    public string? name { get; set; }

    // Navigation property for the memorandums
    public ICollection<MOU01_Memorandum> Memorandums { get; set; }
}