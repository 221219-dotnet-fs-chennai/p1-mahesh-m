using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        public string C_TrainerId { get; set; } = null!;

        public string? C_LastCompanyName { get; set; }

        public int? C_TotalExp { get; set; }

        public int Id { get; set; }
    }
}
