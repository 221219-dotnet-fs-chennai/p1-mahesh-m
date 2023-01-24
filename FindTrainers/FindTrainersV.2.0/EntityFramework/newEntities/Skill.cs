using System;
using System.Collections.Generic;

namespace EntityFramework.newEntities;

public partial class Skill
{
    public string TrainerId { get; set; } = null!;

    public string Skill1 { get; set; } = null!;

    public string Skill2 { get; set; } = null!;

    public string? Skill3 { get; set; }

    public string? Skill4 { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;
}
