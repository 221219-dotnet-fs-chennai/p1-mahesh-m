using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;

namespace BusinessLogic
{
    public class Mapper
    {
        IRepo _repo;
    

        public static   Trainer MapTrainer(Models.Trainer tr)
        {
            return new Trainer()
            { FirstName=tr.T_FirstName, 
              LastName=tr.T_LastName,
              Password = PasswordHasher(tr.T_Password),
              Email=tr.T_Email,
              TrainerId=tr.T_TrainerId,
              PhoneNo=tr.T_PhoneNo,
              City=tr.T_City
            };
        }

        public static  Skill MapSkill(Models.Skill skill)
        {
            return new Skill()
            {
                TrainerId = skill.SK_TrainerId,
                Skill1 = skill.SK_Skill1,
                Skill2 = skill.SK_Skill2,
                Skill3 = skill.SK_Skill3,
                Skill4 = skill.SK_Skill4,
            };
        }

        public static  HighSchool MapHighSchool(Models.HighSchool highSchool)
        {
            return new HighSchool()
            {
                TrainerId = highSchool.HS_TrainerId,
                SchoolName = highSchool.HS_SchoolName,
                YearPassed = highSchool.HS_YearPassed,

            };
        }
        public static  HighSec MapHighSec(Models.HighSec highSec)
        {
            return new HighSec()
            {
                TrainerId = highSec.HSC_TrainerId,
                SchoolName = highSec.HSC_SchoolName,
                YearPassed = highSec.HSC_YearPassed,
                Course = highSec.HSC_Course,
            };

        }

        public static  CollegeUg MapCollege(Models.CollegeUg college)
        {
            return new CollegeUg() {
               TrainerId=college.UG_TrainerId,
                CollegeName= college.UG_CollegeName,
                YearPassed= college.UG_YearPassed,
                Degree= college.UG_Degree,
                Branch= college.UG_Branch,
            
            };

        }

        public static  Company MapCompany (Models.Company company)
        {
            return new Company()
            {
                TrainerId = company.C_TrainerId,
                LastCompanyName = company.C_LastCompanyName,
                TotalExp = company.C_TotalExp,

            };
        }







        public static  Models.CollegeUg MapCollgeInv (CollegeUg college)
        {
            return new Models.CollegeUg() { 
                UG_TrainerId=college.TrainerId,
                UG_CollegeName= college.CollegeName,
                UG_YearPassed = college.YearPassed,
                UG_Branch= college.Branch,
                UG_Degree= college.Degree,

            };

        }

        public static  Models.Trainer MapTrainerInv(Trainer tr)
        {
            return new Models.Trainer()
            {
                T_FirstName = tr.FirstName,
                T_LastName = tr.LastName,
                T_PhoneNo = tr.PhoneNo,
                T_City = tr.City,
                T_Email = tr.Email,
                T_TrainerId = tr.TrainerId,
            };
        }


        public static  Models.Skill MapSkillInv(Skill skill) {

            return new Models.Skill()
            {
                SK_Skill1 = skill.Skill1,
                SK_Skill2 = skill.Skill2,
                SK_Skill3 = skill.Skill3,
                SK_Skill4 = skill.Skill4,
            };
        
        }

        public static  Models.HighSchool MapHighSchoolInv (HighSchool hs)
        {
            return new Models.HighSchool()
            {
                HS_SchoolName = hs.SchoolName,
                HS_YearPassed = hs.YearPassed,

            };
        }

        public static  Models.HighSec MapHighSecInv (HighSec hs)
        {
            return new Models.HighSec()
            {
                HSC_SchoolName = hs.SchoolName,
                HSC_YearPassed = hs.YearPassed,
                HSC_Course = hs.Course,
            };
        }

        public static  Models.Company MapCompanyInv (Company company)
        {
            return new Models.Company()
            {
                C_LastCompanyName = company.LastCompanyName,
                C_TotalExp = company.TotalExp,
            };
        }

        public static string PasswordHasher(string password)
        {
            string newPassword = "";
            char[] pass = password.ToCharArray();
            foreach (char a in pass)
            {
                int asci = (int)a;
                int newAsci = asci + 9;
                newPassword = newPassword + "" + (char)newAsci;
            }

            return newPassword;

        }


    }
}
