using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TDelete : TSignUp, IMenu
    {
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");

        IRepo repo = new SqlRepo(s[0], s[1]);
        public new void Display()
        {
            Console.WriteLine("What do you want to delete?");
            Console.WriteLine();
            Console.WriteLine("[0] Go back :)");
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
            Console.WriteLine("[18] DELETE YOUR ACCOUNT !!!!!");
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
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    string val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("phoneNo", "trainers", userId);
                    }
                    trainer.PhoneNo = "";
                  
                    return "Profile";
                case "3":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                     val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("collegename", "college_ug", userId);
                    }
                    trainer.UGCName = "";
                    return "Profile";
                case "4":

                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                     val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("yearpassed", "college_ug", userId);
                    }
                    trainer.UGPYear="";
                    return "Profile";
                case "5":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("degree", "college_ug", userId);
                    }
                    trainer.UGDegree = "";

                    return "Profile";
                case "6":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("branch", "college_ug", userId);
                    }
                    trainer.UGDept = "";
                    return "Profile";
                case "7":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("Schoolname", "highsec", userId);
                    }

                    trainer.HSCName = "";
               
                    return "Profile";
                case "8":
                   
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("yearpassed", "highsec", userId);
                    }

                    trainer.HSCPYear = "";
              
                    return "Profile";
                case "9":
           
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("course", "highsec", userId);
                    }
                    trainer.HSCStream = "";

                    return "Profile";
                case "10":
                   
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("schoolname", "highschool", userId);
                    }
                    trainer.HSName = "";

                    return "Profile";
                case "11":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("yearpassed", "highschool", userId);
                    }
                    trainer.HSPYear = "";
                    return "Profile";
                case "12":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("lastcompanyname", "comapanies", userId);
                    }
                    trainer.LastCompany = "";
             
                    return "Profile";
                case "13":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("totalexp", "comapanies", userId);
                    }
                    trainer.TotalExp= 0;
                  
                    return "Profile";
                case "14":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("skill_1", "Skills", userId);
                    }
                    trainer.Skill1 = "";
                   
                    return "Profile";
                case "15":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("skill_2", "Skills", userId);
                    }
                    trainer.Skill2 = "";
                    return "Profile";
                case "16":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("skill_3", "Skills", userId);
                    }
                    trainer.Skill3 = "";
                    return "Profile";
                case "17":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.DeleteValues("skill_4", "Skills", userId);
                    }
                    trainer.Skill4 = "";
                    return "Profile";
                case "18":
                    Console.WriteLine("DO YOU WANT TO DELETE YOUR ACCOUNT!!");
                    Console.WriteLine("ARE YOU SURE?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();
                    if (val == "1")
                    {
                        repo.DeleteAccount(userId);
                    }
                    return "Trainer";


                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Profile";
            }
        }
    }
}