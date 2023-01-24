using System;
using System.Collections.Generic;

namespace EntityFramework.newEntities;

public partial class HighSchool
{
    public string TrainerId { get; set; } = null!;

    public string? SchoolName { get; set; }

    public string? YearPassed { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;
}
