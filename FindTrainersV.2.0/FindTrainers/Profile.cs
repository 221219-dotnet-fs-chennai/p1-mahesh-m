using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Datafile;
using EntityFramework.newEntities;
using Serilog;
namespace FindTrainers
{
    internal class Profile : IMenu
    {
       
        Models.Trainer newTr=new Models.Trainer();
        internal static Models.Skill sk = new Models.Skill();
        internal static Models.HighSchool hs = new Models.HighSchool();
        internal static Models.HighSec hsc = new Models.HighSec();
        internal static Models.CollegeUg cug = new Models.CollegeUg();
        internal static Company com = new Company();
        internal static List<Models.Company> companies = new List<Models.Company>();

        TrainerDetails newTrainer =new TrainerDetails();

        public Profile(TrainerDetails trainer) { 
        newTrainer= trainer;
        }

        public Profile(Models.Trainer tra, Models.HighSchool hsl, Models.HighSec hscl, List<Models.Company> cmp, Models.Skill sks, Models.CollegeUg col)
        {
           newTr = tra;
            hs = hsl;
            hsc = hscl;
            companies = cmp;
            sk = sks;
            cug = col;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"<-------------------------- PROFILE PAGE ----------------------------->");
            Console.WriteLine($"Welcome {newTr.FirstName} {newTr.LastName}");
            Console.WriteLine("Hope you are doing good!!");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[0] Log Out :)");
            Console.WriteLine("[1] View your details");
            Console.WriteLine("[2] Update your details");
            Console.WriteLine("[3] Delete your details");
           
        }

        public string UserChoice()
        {
            string ? userInput= Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.WriteLine("Logging out.........");
                    Console.WriteLine("Logged out successfully! :(");
                    Console.WriteLine();
                    return "Trainer";
                case "1":
                    Console.WriteLine("Viewing data..");
                    
                    ViewDetails();
                    return "Profile";
                case "2":
                    return "TUpdate";
                case "3":
                    return "TDelete";
                case "4":
                    return "Menu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return " Menu";

            }

             void ViewDetails()
            { 
                Console.WriteLine();
                Console.WriteLine("Basic Details");
                Console.WriteLine("=====================");
                Console.WriteLine("First Name" + "                            - " + newTr.FirstName);
                Console.WriteLine("Last Name" + "                             - " + newTr.LastName);
                Console.WriteLine("Email ID" + "                              - " + newTr.Email);
                Console.WriteLine("Phone No." + "                             - " + newTr.PhoneNo);
                Console.WriteLine("City" + "                                  -" + newTr.City);


                Console.WriteLine();
                Console.WriteLine("Educational Details");
                Console.WriteLine("=====================");
                Console.WriteLine("Bachelor's College Name" + "               - " + cug.CollegeName);
                Console.WriteLine("Bachelor's Year of Passing" + "            - " + cug.YearPassed);
                Console.WriteLine("Bachelor's Degree" + "                     - " + cug.Degree);
                Console.WriteLine("Bachelor's Specializaiton" + "             - " + cug.Branch);
                Console.WriteLine("HigherSecSchool Name" + "                  - " + hsc.SchoolName);
                Console.WriteLine("HigherSecSchool Year of Passing" + "       - " + hsc.YearPassed);
                Console.WriteLine("HigherSecSchool Stream" + "                - " + hsc.Course);
                Console.WriteLine("HighSchool Name" + "                       - " + hs.SchoolName);
                Console.WriteLine("HighSchool Year of Passing" + "            - " + hs.YearPassed);
                Dictionary<string, string> cm = newTrainer.GetCompany();

                Console.WriteLine();
                Console.WriteLine("Company Details and Experience in years");
                Console.WriteLine("=====================");
                Console.WriteLine();
                var table = new ConsoleTable("Companies", "Experience in Years");


                foreach (var e in companies)
                {
                    table.AddRow(e.LastCompanyName, e.TotalExp);

                }
                table.Write(Format.MarkDown);
                Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine();
                Console.WriteLine("Skills Details");
                Console.WriteLine("=====================");
                Console.WriteLine("Primary Skill" + "                         - " + sk.Skill1);
                Console.WriteLine("Secondary Skill" + "                       - " + sk.Skill2);
                Console.WriteLine("Tertiary Skill" + "                        - " + sk.Skill3);
                Console.WriteLine("Quaternary Skill" + "                      - " + sk.Skill4);
                Console.ReadLine();
            }

        }
    }
}
