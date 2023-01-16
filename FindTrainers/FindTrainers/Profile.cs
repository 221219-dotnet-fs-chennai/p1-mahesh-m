using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Datafile;
using Serilog;
namespace FindTrainers
{
    internal class Profile : IMenu
    {
       

        TrainerDetails newTrainer =new TrainerDetails();

        public Profile(TrainerDetails trainer) { 
        newTrainer= trainer;
        }
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"<-------------------------- PROFILE PAGE ----------------------------->");
            Console.WriteLine($"Welcome {newTrainer.FName} {newTrainer.LName}");
            Console.WriteLine("Hope you are doing good!!");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[0] Log Out :)");
            Console.WriteLine("[1] View your details");
            Console.WriteLine("[2] Update your details");
            Console.WriteLine("[3] Delete your details");
            Console.WriteLine("[4] Delete your account");
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
                    return "Menu";
                case "1":
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
                Console.WriteLine("First Name" + " - " + newTrainer.FName);
                Console.WriteLine("Last Name" + " - " + newTrainer.LName);
                Console.WriteLine("Email ID" + " - " + newTrainer.Email);
                Console.WriteLine("Phone No." + " - " + newTrainer.PhoneNo);


                Console.WriteLine();
                Console.WriteLine("Educational Details");
                Console.WriteLine("=====================");
                Console.WriteLine("Bachelor's College Name" + " - " + newTrainer.UGCName);
                Console.WriteLine("Bachelor's Year of Passing" + " - " + newTrainer.UGPYear);
                Console.WriteLine("Bachelor's Degree" + " - " + newTrainer.UGDegree);
                Console.WriteLine("Bachelor's Specializaiton" + " - " + newTrainer.UGDept);
                Console.WriteLine("HigherSecSchool Name" + " - " + newTrainer.HSCName);
                Console.WriteLine("HigherSecSchool Year of Passing" + " - " + newTrainer.HSCPYear);
                Console.WriteLine("HigherSecSchool Stream" + " - " + newTrainer.HSCStream);
                Console.WriteLine("HighSchool Name" + " - " + newTrainer.HSName);
                Console.WriteLine("HighSchool Year of Passing" + " - " + newTrainer.HSPYear);

                Console.WriteLine();
                Console.WriteLine("Experience Details");
                Console.WriteLine("=====================");
                Console.WriteLine("Last Company Worked" + " - " + newTrainer.LastCompany);
                Console.WriteLine("Total Experience in Years" + " - " + newTrainer.TotalExp);

                Console.WriteLine();
                Console.WriteLine("Skills Details");
                Console.WriteLine("=====================");
                Console.WriteLine("Primary Skill" + " - " + newTrainer.Skill1);
                Console.WriteLine("Secondary Skill" + " - " + newTrainer.Skill2);
                Console.WriteLine("Tertiary Skill" + " - " + newTrainer.Skill3);
                Console.WriteLine("Quaternary Skill" + " - " + newTrainer.Skill4);
            }

        }
    }
}
