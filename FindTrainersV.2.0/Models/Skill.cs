using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skill
    {
        public string SK_TrainerId { get; set; } = null!;

        public string SK_Skill1 { get; set; } = null!;

        public string SK_Skill2 { get; set; } = null!;

        public string? SK_Skill3 { get; set; }

        public string? SK_Skill4 { get; set; }
    }
}
