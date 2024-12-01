using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class MOU_Roles
{
    [Key]
    public int? id { get; set; }
    public string? Code { get; set; }
    public string? Role { get; set; }

    // Navigation property for the roles
    public ICollection<EMO_Roles>? Roles { get; set; }
}