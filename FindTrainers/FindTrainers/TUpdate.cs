using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TUpdate : TSignUp, IMenu
    {
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");
        Dictionary<string, string> comp = trainer.GetCompany();

        IRepo repo = new SqlRepo(s[0], s[1]);
        public new void Display()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------- Update Page  -------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++PRESS THE RESPECTIVE NOS. TO GIVE RESPECTIVE INPUTS++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Controls");
            Console.WriteLine("===========");
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine();


            Console.WriteLine("Basic Details");
            Console.WriteLine("=================");
            Console.WriteLine();

            Console.WriteLine("[1] Phone No." + "                            - " + trainer.PhoneNo);
            Console.WriteLine();


            Console.WriteLine("UG Details");
            Console.WriteLine("=============");
            Console.WriteLine();


            Console.WriteLine("[2] Bachelor's College Name" + "              - " + trainer.UGCName);
            Console.WriteLine("[3] Bachelor's Year of Passing" + "           - " + trainer.UGPYear);
            Console.WriteLine("[4] Bachelor's Degree" + "                    - " + trainer.UGDegree);
            Console.WriteLine("[5] Bachelor's Specializaiton" + "            - " + trainer.UGDept);
            Console.WriteLine();


            Console.WriteLine("Higher Secondary School Details");
            Console.WriteLine("==================================");
            Console.WriteLine();


            Console.WriteLine("[6] HigherSecSchool Name" + "                - " + trainer.HSCName);
            Console.WriteLine("[7] HigherSecSchool Year of Passing" + "     - " + trainer.HSCPYear);
            Console.WriteLine("[8] HigherSecSchool Stream" + "              - " + trainer.HSCStream);
            Console.WriteLine();



            Console.WriteLine("High School Details");
            Console.WriteLine("======================");
            Console.WriteLine();


            Console.WriteLine("[9] HighSchool Name" + "                     - " + trainer.HSName);
            Console.WriteLine("[10] HighSchool Year of Passing" + "          - " + trainer.HSPYear);
            Console.WriteLine();


            Console.WriteLine("Experience Details");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Console.WriteLine("[11] Company Details" + "                     - ");
            foreach (var e in comp)
            {
                Console.WriteLine("          ---------------------------");
                Console.WriteLine("            " + e.Key + "        |          " + e.Value + "    ");
                Console.WriteLine("          ---------------------------");
            }


            Console.WriteLine("Skill set");
            Console.WriteLine("============");
            Console.WriteLine();


            Console.WriteLine("[12] Primary Skill" + "                       - " + trainer.Skill1);
            Console.WriteLine("[13] Secondary Skill" + "                     - " + trainer.Skill2);
            Console.WriteLine("[14] Tertiary Skill" + "                      - " + trainer.Skill3);
            Console.WriteLine("[15] Quaternary Skill" + "                    - " + trainer.Skill4);
            Console.WriteLine();
            Console.WriteLine();
           

        }

        public new string UserChoice()
        {
            String[] arr = trainer.Email.Split("@");
            string userId = arr[0];
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Profile";

                case "1":
                    Console.WriteLine("Enter New Phone No.");
                    trainer.PhoneNo = Console.ReadLine();
                    repo.UpdateATrainer(trainer.PhoneNo, "phoneNo", "trainers", userId);
                    Log.Information("Trainer updated his/her phone no.");
                    
                    return "Profile";
                case "2":
                    Console.WriteLine("Enter New Bachelor's College Name");
                    trainer.UGCName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGCName, "collegeName", "colleg_ug", userId);
                    Log.Information("Trainer update his/her College Name");
                    return "Profile";
                case "3":
                    Console.WriteLine("Enter New Bachelor's Year of Passing");
                    trainer.UGPYear = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGPYear, "yearpassed", "college_ug", userId);
                    Log.Information("user updates his/her UG year");
                    return "Profile";
                case "4":
                    Console.WriteLine("Enter New Bachelor's Degree");
                    trainer.UGDegree = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGDegree, "degree", "college_ug", userId);
                    Log.Information("user updates his/her Bachelors degree");
                    return "Profile";
                case "5":
                    Console.WriteLine("Enter New Bachelor's Specialization");
                    trainer.UGDept = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGDept, "branch", "college_ug", userId);
                    Log.Information("user updates his/her Bachelors specialization");
                    return "Profile";
                case "6":
                    Console.WriteLine("Enter New HigherSec School Name");
                    trainer.HSCName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSCName, "Schoolname", "highsec", userId);
                    Log.Information("user updates his/her HSC school name");
                    return "Profile";
                case "7":
                    Console.WriteLine("Enter New HigherSec School Year of Passing");
                    repo.UpdateATrainer(trainer.HSCPYear, "yearpassed", "highsec", userId);
                    trainer.HSCPYear = Console.ReadLine();
                    Log.Information("user updates his/her HSCP year");
                    return "Profile";
                case "8":
                    Console.WriteLine("Enter New HigherSec School Stream");
                    trainer.HSCStream = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSCStream, "course", "highsec", userId);
                    Log.Information("user updates his/her HSC stream");
                    return "Profile";
                case "9":
                    Console.WriteLine("Enter New High School Name");
                    trainer.HSName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSName, "schoolname", "highschool", userId);
                    Log.Information("User updates his/her HS Name");
                    return "Profile";
                case "10":
                    Console.WriteLine("Enter New High School Year of Passing");
                    trainer.HSPYear = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSPYear, "yearpassed", "highschool", userId);
                    Log.Information("user updates his/her HS Year of Passing");
                    return "Profile";
                case "11":
                 
                    Console.WriteLine("Enter the company name");
                    string newC=Console.ReadLine();
               
                    Console.WriteLine("Enter the experience to that company");
                    string exp=Console.ReadLine();
                    trainer.SetCompany(newC, exp);
                    repo.UpdateCompanies(newC,exp, userId);
                    Log.Information("User updates his/her Experience details");
                    return "Profile";
                case "12":
                    Console.WriteLine("Enter New your Primary Skill");
                    trainer.Skill1 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill1, "skill_1", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "13":
                    Console.WriteLine("Enter New your Secondary Skill");
                    trainer.Skill2 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill2, "skill_2", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "14":
                    Console.WriteLine("Enter New your Tertiary Skill");
                    trainer.Skill3 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill3, "skill_3", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "15":
                    Console.WriteLine("Enter New your Quaternary Skill");
                    trainer.Skill4 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill4, "skill_4", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Profile";
            }
        }
    }
}
