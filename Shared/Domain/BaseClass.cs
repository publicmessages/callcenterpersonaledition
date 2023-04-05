using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace CallCenter.Shared.Domain;

public abstract class BaseClass
{
    [NotMapped]
    public Stopwatch Stopwatch { get; set; } = new Stopwatch();
}
