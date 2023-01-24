using System;
using System.Collections.Generic;

namespace EntityFramework.newEntities;

public partial class Company
{
    public string TrainerId { get; set; } = null!;

    public string? LastCompanyName { get; set; }

    public int? TotalExp { get; set; }

    public int Id { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;
}
