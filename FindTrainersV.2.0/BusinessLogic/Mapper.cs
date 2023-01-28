using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal class Mapper
    {

        public Trainer MapTrainer(Models.Trainer tr)
        {
            return new Trainer()
            { FirstName=tr.FirstName, 
              LastName=tr.LastName,
              Password=tr.Password,
              TrainerId=tr.TrainerId,
              PhoneNo=tr.PhoneNo,
              City=tr.City
            };
        }

        public Skill MapSkill(Models.Skill skill)
        {
            return new Skill()
            {
                TrainerId = skill.TrainerId,
                Skill1 = skill.Skill1,
                Skill2 = skill.Skill2,
                Skill3 = skill.Skill3,
                Skill4 = skill.Skill4,
            };
        }

        public HighSchool MapHighSchool(Models.HighSchool highSchool)
        {
            return new HighSchool()
            {
                TrainerId = highSchool.TrainerId,
                SchoolName = highSchool.SchoolName,
                YearPassed = highSchool.YearPassed,

            };
        }
        public HighSec MapHighSec(Models.HighSec highSec)
        {
            return new HighSec()
            {
                TrainerId = highSec.TrainerId,
                SchoolName = highSec.SchoolName,
                YearPassed = highSec.YearPassed,
                Course = highSec.Course,
            };

        }

        public CollegeUg MapCollege(Models.CollegeUg college)
        {
            return new CollegeUg() {
            
                CollegeName= college.CollegeName,
                YearPassed= college.YearPassed,
                Degree= college.Degree,
                Branch= college.Branch,
            
            };

        }

        public Company MapCompany (Models.Company company)
        {
            return new Company()
            {
                TrainerId = company.TrainerId,
                LastCompanyName = company.LastCompanyName,
                TotalExp = company.TotalExp,

            };
        }







        public Models.CollegeUg MapCollgeInv (CollegeUg college)
        {
            return new Models.CollegeUg() { 
            
                CollegeName= college.CollegeName,
                YearPassed = college.YearPassed,
                Branch= college.Branch,
                Degree= college.Degree,

            };

        }

        public Models.Trainer MapTrainerInv(Trainer tr)
        {
            return new Models.Trainer()
            {
                FirstName = tr.FirstName,
                LastName = tr.LastName,
                PhoneNo = tr.PhoneNo,
                City = tr.City,
                Email = tr.Email,
                TrainerId = tr.TrainerId,
            };
        }


        public Models.Skill MapSkillInv(Skill skill) {

            return new Models.Skill()
            {
                Skill1 = skill.Skill1,
                Skill2 = skill.Skill2,
                Skill3 = skill.Skill3,
                Skill4 = skill.Skill4,
            };
        
        }

        public Models.HighSchool MapHighSchoolInv (HighSchool hs)
        {
            return new Models.HighSchool()
            {
                SchoolName = hs.SchoolName,
                YearPassed = hs.YearPassed,

            };
        }

        public Models.HighSec MapHighSecInv (HighSec hs)
        {
            return new Models.HighSec()
            {
                SchoolName = hs.SchoolName,
                YearPassed = hs.YearPassed,
                Course = hs.Course,
            };
        }

        public Models.Company MapCompanyInv (Company company)
        {
            return new Models.Company()
            {
                LastCompanyName = company.LastCompanyName,
                TotalExp = company.TotalExp,
            };
        }


    }
}
