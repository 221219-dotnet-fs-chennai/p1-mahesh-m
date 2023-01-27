using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public interface IRepo
    {

        void InsertTrainers(Trainer Tr,Skill sk,HighSec hsc,HighSchool hs,List<Company> com,CollegeUg ug);

        Trainer GetTrainer(string trainerId);
        HighSchool GetHighSchool(string trainerId);
        HighSec GetHighSec(string trainerId);
        Skill GetSkill(string trainerId);
        List<Company> GetCompany(string trainerId);

        CollegeUg GetCollegeUg(string trainerId);

        void UpdateATrainer(string newVal, string table, string column, string trainerId);

    }
}
