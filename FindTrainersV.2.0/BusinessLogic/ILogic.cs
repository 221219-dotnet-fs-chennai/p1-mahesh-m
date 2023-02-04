using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        void InsertTrainers(Models.Trainer Tr, Models.Skill sk, Models.HighSec hsc, Models.HighSchool hs, List<Models.Company> com, Models.CollegeUg ug);

        Models.Trainer GetTrainer(string trainerId);
        Models.HighSchool GetHighSchool(string trainerId);
        Models.HighSec GetHighSec(string trainerId);
        Models.Skill GetSkill(string trainerId);
        List<Models.Company> GetCompany(string trainerId);

        Models.CollegeUg GetCollegeUg(string trainerId);

        void UpdateATrainer(string newVal, string table, string column, string trainerId);

        public void UpdateCompanies(string newC, string newExp, string userId);
        public void DeleteSingleCompany(string cnmae, string userid);
        void DeleteAccount(string trainerId);
        bool Login(string email);

        IEnumerable<Models.TResult> GetAll();

        IEnumerable<Models.TResult> TrainersBySkill(string skill);
        IEnumerable<Models.TResult> TrainersByLocation(string city);

        bool IsExist(string str, string type);
    }
}
