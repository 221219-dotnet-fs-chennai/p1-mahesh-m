using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.newEntities
{
    public class TResult
    {
        public string TrainerId { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNo { get; set; }

        public string? Email { get; set; }
        public string? City { get; set; }

        public string Skill1 { get; set; } = null!;

    }
}
