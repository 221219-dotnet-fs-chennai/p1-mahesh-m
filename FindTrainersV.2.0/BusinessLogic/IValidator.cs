using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public  interface IValidator
    {
        bool Validator(string str, string type, string field);

    }
}
