using System;
using System.Collections.Generic;

namespace EntityFramework.newEntities;

public partial class CollegeUg
{
    public string TrainerId { get; set; } = null!;

    public string? CollegeName { get; set; }

    public string? YearPassed { get; set; }

    public string? Degree { get; set; }

    public string? Branch { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;
}
