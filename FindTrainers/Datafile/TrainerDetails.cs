using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datafile
{
    public class TrainerDetails
    {
        string? email;
        string? password;
        string? fName;
        string? lName;
        string? phoneNo;
        string? city;

        string? uGCName;
        string? uGPYear;
        string? uGDegree;
        string? uGDept;

        string? hSCName;
        string? hSCPYear;
        string? hSCStream;

        string? hSName;
        string? hSPYear;

        string? skill1;
        string? skill2;
        string? skill3;
        string? skill4;

        Dictionary<string, string> company = new Dictionary<string, string>();

        public void SetCompany(string cname, string exp)
        {
            company.Add(cname, exp);
        }

        public Dictionary<string, string> GetCompany()
        {
            return company;
        }
       
        public string ? City { get; set; }

        public string? Email
        {
            get;
            set;
        }

        public string? Password
        {
            get;
            set;
        }

        public string? FName
        {
            get;
            set;
        }

        public string? LName
        {
            get;
            set;
        }
        public string? UGCName
        {
            get;
            set;
        }

        public string? UGPYear
        {
            get;
            set;
        }

        public string? UGDept
        {
            get;
            set;
        }

        public string? HSCName
        {
            get;
            set;
        }

        public string? HSCPYear
        {
            get;
            set;
        }

        public string? HSCStream
        {
            get;
            set;
        }

        public string? HSName
        {
            get;
            set;
        }

        public string? HSPYear
        {
            get;
            set;
        }

        public string? Skill1
        {
            get;
            set;
        }

        public string? Skill2
        {
            get;
            set;
        }

        public string? Skill3
        {
            get;
            set;
        }

        public string? Skill4
        {
            get;
            set;
        }

     
        public string? PhoneNo
        {
            get;
            set;
        }

        public string? UGDegree
        {
            get;
            set;
        }
       
    }
}
