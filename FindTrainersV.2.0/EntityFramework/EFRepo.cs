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
        public Trainer GetTrainer(string tId)
        {
            var context = new TrainerDetailsContext();
            var trainers=context.Trainers;
            var tr= from t in trainers
                    where t.TrainerId== tId
                    select t;
            Trainer trb = new Trainer();
            foreach (var t in tr)
            {
                trb = new Trainer()
                {
                    FirstName= t.FirstName,
                    LastName= t.LastName,
                    PhoneNo= t.PhoneNo,
                    TrainerId= t.TrainerId,
                    Email= t.Email,
                    City= t.City,
                    
                };

            }
            return trb;

        }

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
