using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datafile
{ 
    public interface IRepo
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        TrainerDetails Insert (TrainerDetails trainer);
        bool Login(string email);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns true if the user has an account in the </returns>
        TrainerDetails GetATrainer(string email);

        /// <summary>
        /// updates Trainer details except companies
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="columnName"></param>
        /// <param name="tableName"></param>
        /// <param name="trainerId"></param>
        void UpdateATrainer(string newValue, string columnName, string tableName,string trainerId);

        /// <summary>
        /// updates 
        /// </summary>
        /// <param name="newC"></param>
        /// <param name="newExp"></param>
        /// <param name="userId"></param>
        void UpdateCompanies(string newC, string newExp,string userId);

        void DeleteCompanies(string userId);

        void DeleteValues(string columnName, string tableName,string trainerId);

        void DeleteAccount(string trainerId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>list of all trainers</returns>
        List<TrainerDetails> GetAll();
        /// <summary>
        /// creates new password
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="email"></param>
        void NewPass(string pass, string email);

        bool IsExist(string value,string column);

        //void DeleteSingleCompany(string cname, string userid);

       

    }
}
