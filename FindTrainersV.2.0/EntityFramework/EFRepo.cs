using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class EFRepo : IRepo
    {
        public CollegeUg GetCollegeUg(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var cug = context.CollegeUgs;
            var ug= from s in cug
                    where s.TrainerId==trainerId
                    select s;
            CollegeUg collug = new CollegeUg(); 
            foreach(var s in ug)
            {
                collug = new CollegeUg()
                {
                    CollegeName= s.CollegeName,
                    YearPassed= s.YearPassed,
                    Branch=s.Branch,
                    Degree  =s.Degree,

                };
            }
            return collug;  
        }

        public List<Company> GetCompany(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var comp = context.Companies;
            var cmp= from s in comp
                     where s.TrainerId== trainerId
                     select s;
            return cmp.ToList();    
        }

        public HighSchool GetHighSchool(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var hscl = context.HighSchools;
            var hsc = from s in hscl
                      where s.TrainerId == trainerId
                      select s;
            HighSchool highsch = new HighSchool();
            foreach (var s in hsc)
            {
                highsch = new HighSchool()
                {
                    SchoolName = s.SchoolName,
                    YearPassed = s.YearPassed,
                    

                };
            }
            return highsch;
        }

        public HighSec GetHighSec(string trainerId)
        {
            var context = new TrainerDetailsContext();
            var hscl =  context.HighSecs;
            var hsc = from s in hscl
                     where s.TrainerId == trainerId
                     select s;
            HighSec highsec = new HighSec();
            foreach (var s in hsc )
            {
                highsec= new HighSec()
                {
                   SchoolName= s.SchoolName,
                   YearPassed= s.YearPassed,
                   Course=  s.Course
                 
                };
            }
            return highsec;
        }

        public Skill GetSkill(string tId)
        {
            var context = new TrainerDetailsContext();
            var Skills = context.Skills;
            var sk= from s in Skills
                    where s.TrainerId==tId
                    select s;
           Skill skb=new Skill();
            foreach(var s in sk)
            {
                skb = new Skill()
                {
                    Skill1 = s.Skill1,
                    Skill2 = s.Skill2,
                    Skill3 = s.Skill3,
                    Skill4 = s.Skill4,
                };
            }
            return skb;
        }

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

        public void UpdateATrainer(string newVal, string table, string column, string trainerId)
        {
            var context =new TrainerDetailsContext();
            var trainers=context.Trainers;
            var tr= from t in trainers
                    where t.TrainerId== trainerId
                    select t;
            foreach(var rec in tr) {
                rec.PhoneNo = newVal;
            }
            context.SaveChanges();

        }
    }
}
