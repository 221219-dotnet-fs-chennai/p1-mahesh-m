using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datafile
{
    public interface IRepo
    {
        TrainerDetails Insert (TrainerDetails trainer);
        bool Login(string email);

        TrainerDetails GetATrainer(string email);

        void UpdateATrainer(string newValue, string columnName, string tableName,string trainerId);

        void DeleteValues(string columnName, string tableName,string trainerId);

        void DeleteAccount(string trainerId);

    }
}
