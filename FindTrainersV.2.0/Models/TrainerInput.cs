using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainerInput
    {
       

        public string? T_FirstName { get; set; }

        public string? T_LastName { get; set; }

        public string? T_PhoneNo { get; set; }

        public string? T_Email { get; set; }


        public string? T_Password { get; set; }

        public string? T_City { get; set; }

        public string SK_Skill1 { get; set; } = null!;

        public string SK_Skill2 { get; set; } = null!;

        public string? SK_Skill3 { get; set; }

        public string? SK_Skill4 { get; set; }

        public string? HSC_SchoolName { get; set; }

        public string? HSC_YearPassed { get; set; }

        public string? HSC_Course { get; set; }

        public string? HS_SchoolName { get; set; }

        public string? HS_YearPassed { get; set; }

        public string? C_LastCompanyName { get; set; }

        public int? C_TotalExp { get; set; }
        public string? UG_CollegeName { get; set; }

        public string? UG_YearPassed { get; set; }

        public string? UG_Degree { get; set; }

        public string? UG_Branch { get; set; }


    }
}
