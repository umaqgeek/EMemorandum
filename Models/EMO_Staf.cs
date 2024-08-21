using System.ComponentModel.DataAnnotations;

namespace EMemorandum.Models;

public class EMO_Staf
{
    [Key]
    public string NoStaf { get; set; }
    public string Nama { get; set; }
    public string Email { get; set; }
}