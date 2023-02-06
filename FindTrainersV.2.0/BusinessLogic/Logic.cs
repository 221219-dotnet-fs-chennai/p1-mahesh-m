using EntityFramework;
using EntityFramework.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic
{  

    public class Logic: ILogic
    {
      
        IRepo repo;
       
        public Logic(IRepo _repo)
        {
            repo = _repo;
        }

        public Logic()
        {

        }

        public void DeleteAccount(string trainerId)
        {
            repo.DeleteAccount(trainerId);
        }

        public void DeleteSingleCompany(string cnmae, string userid)
        {
          repo.DeleteSingleCompany(cnmae, userid);

        }

        public Models.CollegeUg GetCollegeUg(string trainerId)
        {
            return Mapper.MapCollgeInv(repo.GetCollegeUg(trainerId));
            
        }

        public List<Models.Company> GetCompany(string trainerId)
        {
            var company = repo.GetCompany(trainerId);
            List<Models.Company> cm= new List<Models.Company>();
            foreach(var c in company)
            {
                cm.Add(Mapper.MapCompanyInv(c));
            }

            return cm;


        }

        public Models.HighSchool GetHighSchool(string trainerId)
        {
            return Mapper.MapHighSchoolInv(repo.GetHighSchool(trainerId));
        }

        public Models.HighSec GetHighSec(string trainerId)
        {
            return Mapper.MapHighSecInv(repo.GetHighSec(trainerId));
        }

        public Models.Skill GetSkill(string tId)
        {
            return Mapper.MapSkillInv(repo.GetSkill(tId));
        }

    

        public Models.Trainer GetTrainer(string tId)
        {

        return Mapper.MapTrainerInv(repo.GetTrainer(tId));

        }

        public void InsertTrainers(Models.Trainer tr, Models.Skill sk, Models.HighSec hsc, Models.HighSchool hs, List<Models.Company> com, Models.CollegeUg ug)
        {  List<Company> companies= new List<Company>();
            foreach(var c in com) {
            companies.Add(Mapper.MapCompany(c));
            }
            repo.InsertTrainers(Mapper.MapTrainer(tr), Mapper.MapSkill(sk), Mapper.MapHighSec(hsc), Mapper.MapHighSchool(hs), companies, Mapper.MapCollege(ug));
        }

        public bool Login(string email,string password)
        {

            return repo.Login(email,password);   
        }

        public void UpdateATrainer(string newVal, string column, string table, string trainerId)
        {
           repo.UpdateATrainer(newVal, column, table, trainerId);   
        }

        public void UpdateCompanies(string newC, string newExp, string userId)
        {
           repo.UpdateCompanies(newC, newExp, userId);
        }

        public string PasswordHasher(string password)
        {
           return repo.PasswordHasher(password);

        }

        public IEnumerable<Models.TResult> GetAll()
        {
            return repo.GetAll();   
        }

        public IEnumerable<Models.TResult> TrainersBySkill(string skill)
        {
           return repo.TrainersBySkill(skill);
        }

        public IEnumerable<Models.TResult> TrainersByLocation(string city)
        {
          return repo.TrainersByLocation(city);
        }

        public bool IsExist(string str, string type)
        {
           return repo.IsExist(str, type);

        }
    }
    }


