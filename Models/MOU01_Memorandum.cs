using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EMemorandum.Models;

public class MOU01_Memorandum
{
    [Key]
    public string NoMemo { get; set; }
    public string NoSiri { get; set; }
    public int Tahun { get; set; }

    [ForeignKey("PUU_SubPTj")]
    public string KodPTJ { get; set; }

    [ForeignKey("PUU_ScopeMemo")]
    public int KodScope { get; set; }

    [ForeignKey("PUU_JenisMemo")]
    public int KodJenis { get; set; }

    [ForeignKey("PUU_KategoriMemo")]
    public int KodKategori { get; set; }

    public string KodPTJSub { get; set; }
    public DateTime TarikhMula { get; set; }
    public DateTime TarikhTamat { get; set; }
    public string TajukProjek { get; set; }
    public string NamaDok { get; set; }
    public string Path { get; set; }

    [ForeignKey("EMO_Staf")]
    public string MS01_NoStaf { get; set; }

    [ForeignKey("MOU_Status")]
    public string Status { get; set; }
    public decimal Nilai { get; set; }

    [JsonIgnore]  // This will prevent the EMO_Staf reference from being serialized
    public EMO_Staf EMO_Staf { get; set; }  // Navigation property back to EMO_Staf

    [JsonIgnore]  // This will prevent the PUU_ScopeMemo reference from being serialized
    public PUU_ScopeMemo PUU_ScopeMemo { get; set; }  // Navigation property back to PUU_ScopeMemo

    [JsonIgnore]  // This will prevent the PUU_JenisMemo reference from being serialized
    public PUU_JenisMemo PUU_JenisMemo { get; set; }  // Navigation property back to PUU_JenisMemo

    [JsonIgnore]  // This will prevent the PUU_KategoriMemo reference from being serialized
    public PUU_KategoriMemo PUU_KategoriMemo { get; set; }  // Navigation property back to PUU_KategoriMemo

    [JsonIgnore]  // This will prevent the PUU_SubPTj reference from being serialized
    public PUU_SubPTj PUU_SubPTj { get; set; }  // Navigation property back to PUU_SubPTj

    [JsonIgnore]  // This will prevent the MOU_Status reference from being serialized
    public MOU_Status MOU_Status { get; set; }  // Navigation property back to MOU_Status
}