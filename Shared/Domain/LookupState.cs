using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenter.Shared.Domain;

[Table("LUP_State")]
public partial class LookupState
{
    public string StateCode { get; set; } = "";
    public string? StateName { get; set; }
}
