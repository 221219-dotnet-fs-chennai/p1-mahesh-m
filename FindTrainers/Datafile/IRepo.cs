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
    }
}
