using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class MOU_Field
{
    [Key]
    public string? KodField { get; set; }
    public string? Field { get; set; }

    // Navigation property for the MOU07_Field
    public ICollection<MOU07_Field>? MOU07_Fields { get; set; }
}