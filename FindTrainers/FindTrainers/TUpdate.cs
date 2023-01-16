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

        IRepo repo = new SqlRepo(s[0], s[1]);
        public new void Display()
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to update?");
            Console.WriteLine();
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Save");
            Console.WriteLine("[2] Phone No." + " - " + trainer.PhoneNo);
            Console.WriteLine("[3] Bachelor's College Name" + " - " + trainer.UGCName);
            Console.WriteLine("[4] Bachelor's Year of Passing" + " - " + trainer.UGPYear);
            Console.WriteLine("[5] Bachelor's Degree" + " - " + trainer.UGDegree);
            Console.WriteLine("[6] Bachelor's Specializaiton" + " - " + trainer.UGDept);
            Console.WriteLine("[7] HigherSecSchool Name" + " - " + trainer.HSCName);
            Console.WriteLine("[8] HigherSecSchool Year of Passing" + " - " + trainer.HSCPYear);
            Console.WriteLine("[9] HigherSecSchool Stream" + " - " + trainer.HSCStream);
            Console.WriteLine("[10] HighSchool Name" + " - " + trainer.HSName);
            Console.WriteLine("[11] HighSchool Year of Passing" + " - " + trainer.HSPYear);
            Console.WriteLine("[12] Last Company Worked" + " - " + trainer.LastCompany);
            Console.WriteLine("[13] Total Experience in Years" + " - " + trainer.TotalExp);
            Console.WriteLine("[14] Primary Skill" + " - " + trainer.Skill1);
            Console.WriteLine("[15] Secondary Skill" + " - " + trainer.Skill2);
            Console.WriteLine("[16] Tertiary Skill" + " - " + trainer.Skill3);
            Console.WriteLine("[17] Quaternary Skill" + " - " + trainer.Skill4);

        }

        public new string UserChoice()
        {
            String[] arr = trainer.Email.Split("@");
            string userId = arr[0];
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Trainer";
                case "1":


                    return "Profile";

                case "2":
                    Console.WriteLine("Enter New Phone No.");
                    trainer.PhoneNo = Console.ReadLine();
                    repo.UpdateATrainer(trainer.PhoneNo, "phoneNo", "trainers", userId);
                    return "Profile";
                case "3":
                    Console.WriteLine("Enter New Bachelor's College Name");
                    trainer.UGCName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGCName, "collegeName", "colleg_ug", userId);
                    return "Profile";
                case "4":
                    Console.WriteLine("Enter New Bachelor's Year of Passing");
                    trainer.UGPYear = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGPYear, "yearpassed", "college_ug", userId);
                    return "Profile";
                case "5":
                    Console.WriteLine("Enter New Bachelor's Degree");
                    trainer.UGDegree = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGDegree, "degree", "college_ug", userId);
                    return "Profile";
                case "6":
                    Console.WriteLine("Enter New Bachelor's Specialization");
                    trainer.UGDept = Console.ReadLine();
                    repo.UpdateATrainer(trainer.UGDept, "branch", "college_ug", userId);
                    return "Profile";
                case "7":
                    Console.WriteLine("Enter New HigherSec School Name");
                    trainer.HSCName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSCName, "Schoolname", "highsec", userId);
                    return "Profile";
                case "8":
                    Console.WriteLine("Enter New HigherSec School Year of Passing");
                    repo.UpdateATrainer(trainer.HSCPYear, "yearpassed", "highsec", userId);
                    trainer.HSCPYear = Console.ReadLine();
                    return "Profile";
                case "9":
                    Console.WriteLine("Enter New HigherSec School Stream");
                    trainer.HSCStream = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSCStream, "course", "highsec", userId);
                    return "Profile";
                case "10":
                    Console.WriteLine("Enter New High School Name");
                    trainer.HSName = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSName, "schoolname", "highschool", userId);
                    return "Profile";
                case "11":
                    Console.WriteLine("Enter New High School Year of Passing");
                    trainer.HSPYear = Console.ReadLine();
                    repo.UpdateATrainer(trainer.HSPYear, "yearpassed", "highschool", userId);
                    return "Profile";
                case "12":
                    Console.WriteLine("Enter New Last Company Name");
                    trainer.LastCompany = Console.ReadLine();
                    repo.UpdateATrainer(trainer.LastCompany, "lastcompanyname", "comapanies", userId);
                    return "Profile";
                case "13":
                    Console.WriteLine("Enter New total experience in years");
                    trainer.TotalExp = Convert.ToInt32(Console.ReadLine());
                    int ?exp = trainer.TotalExp;
                    string ex = "";
                    ex = ex + exp;
                    repo.UpdateATrainer(ex, "totalexp", "companies", userId);
                    return "Profile";
                case "14":
                    Console.WriteLine("Enter New your Primary Skill");
                    trainer.Skill1 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill1, "skill_1", "Skills", userId);
                    return "Profile";
                case "15":
                    Console.WriteLine("Enter New your Secondary Skill");
                    trainer.Skill2 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill2, "skill_2", "Skills", userId);
                    return "Profile";
                case "16":
                    Console.WriteLine("Enter New your Tertiary Skill");
                    trainer.Skill3 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill3, "skill_3", "Skills", userId);
                    return "Profile";
                case "17":
                    Console.WriteLine("Enter New your Quaternary Skill");
                    trainer.Skill4 = Console.ReadLine();
                    repo.UpdateATrainer(trainer.Skill4, "skill_4", "Skills", userId);
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
