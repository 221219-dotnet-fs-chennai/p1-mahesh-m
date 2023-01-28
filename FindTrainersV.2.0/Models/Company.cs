using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        public string TrainerId { get; set; } = null!;

        public string? LastCompanyName { get; set; }

        public int? TotalExp { get; set; }

        public int Id { get; set; }
    }
}
