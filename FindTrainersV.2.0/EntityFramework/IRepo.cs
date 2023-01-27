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

    }
}
