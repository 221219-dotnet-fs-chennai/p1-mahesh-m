using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skill
    {
        public string TrainerId { get; set; } = null!;

        public string Skill1 { get; set; } = null!;

        public string Skill2 { get; set; } = null!;

        public string? Skill3 { get; set; }

        public string? Skill4 { get; set; }
    }
}
