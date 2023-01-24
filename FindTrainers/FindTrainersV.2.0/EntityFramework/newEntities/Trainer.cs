using System;
using System.Collections.Generic;

namespace EntityFramework.newEntities;

public partial class Trainer
{
    public string TrainerId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? City { get; set; }

    public virtual CollegeUg? CollegeUg { get; set; }

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual HighSchool? HighSchool { get; set; }

    public virtual HighSec? HighSec { get; set; }

    public virtual Skill? Skill { get; set; }
}
