using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class EFRepo : IRepo
    {
        public void InsertTrainers(Trainer tr, Skill sk, HighSec hsc, HighSchool hs, List<Company> com, CollegeUg ug)
        {
            var context =new  TrainerDetailsContext();
            context.Trainers.Add(tr);
            context.Skills.Add(sk);
            context.HighSchools.Add(hs);
            context.HighSecs.Add(hsc);
            context.CollegeUgs.Add(ug);
            foreach(var company in com)
            {
                context.Companies.Add(company);
            }

            context.SaveChanges();

        }
    }
}
