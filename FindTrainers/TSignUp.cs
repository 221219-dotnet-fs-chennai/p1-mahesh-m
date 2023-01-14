using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace FT_UIConsole
{
    internal class TSignUp : IMenu
    {   TrainerDetails trainer = new TrainerDetails();
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("-----------Add Your Details------------");
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Save");
            Console.WriteLine("[2] First Name"+" "+trainer.FName);
            Console.WriteLine("[3] Last Name"+" "+trainer.LName);
            Console.WriteLine("[4] Email ID" + " "+trainer.Email);
            Console.WriteLine("[5] Phone No." + " "+trainer.PhoneNo);
            Console.WriteLine("[6] Bachelor's College Name" + " "+trainer.UGCName);
            Console.WriteLine("[7] Bachelor's Year of Passing" + " "+trainer.UGPYear);
            Console.WriteLine("[8] Bachelor's Degree" + " "+trainer.UGDegree);
            Console.WriteLine("[9] Bachelor's Specializaiton"+" "+trainer.UGDept);
            Console.WriteLine("[10] HigherSecSchool Name"+" "+trainer.HSCName);
            Console.WriteLine("[11] HigherSecSchool Year of Passing" + " "+trainer.HSCPYear);
            Console.WriteLine("[12] HigherSecSchool Stream" + " "+trainer.HSCStream);
            Console.WriteLine("[13] HighSchool Name" + " "+trainer.HSName);
            Console.WriteLine("[14] HighSchool Year of Passing" + " " + trainer.HSPYear);
            Console.WriteLine("[15] Last Company Worked" + " "+trainer.LastCompany);
            Console.WriteLine("[16] Total Experience in Years" + " "+trainer.TotalExp);
            Console.WriteLine("[17] Primary Skill" + " "+trainer.Skill1);
            Console.WriteLine("[18] Secondary Skill" + " "+trainer.Skill2);
            Console.WriteLine("[19] Tertiary Skill" + " "+trainer.Skill3);
            Console.WriteLine("[20] Quaternary Skill" + " "+trainer.Skill4);
        }

        public string UserChoice()
        {
            string? userInput=Console.ReadLine();
            
            switch(userInput)
            {
                case "0":
                    return "Menu";
                case "1":
                    return "Menu";

                case "2":
                    Console.WriteLine("Enter First Name");
                    trainer.FName = Console.ReadLine();
                    return "TSignUp";
                case"3":
                    Console.WriteLine("Enter Last Name");
                    trainer.LName = Console.ReadLine();
                    return "TSignUp";
                case"4":
                    Console.WriteLine("Enter Email ID");
                    trainer.Email = Console.ReadLine();
                    return "TSignUp";
                case "5":
                    Console.WriteLine("Enter Phone No.");
                    trainer.PhoneNo = Console.ReadLine();
                    return "TSignUp";
                case "6":
                    Console.WriteLine("Enter Bachelor's College Name");
                    trainer.UGCName = Console.ReadLine();
                    return "TSignUp";
                case "7":
                    Console.WriteLine("Enter Bachelor's Year of Passing");
                    trainer.UGPYear = Console.ReadLine();
                    return "TSignUp";
                case "8":
                    Console.WriteLine("Enter Bachelor's Degree");
                    trainer.UGDegree = Console.ReadLine();
                    return "TSignUp";
                case "9":
                    Console.WriteLine("Enter Bachelor's Specialization");
                    trainer.UGDept = Console.ReadLine();
                    return "TSignUp";
                case "10":
                    Console.WriteLine("Enter HigherSec School Name");
                    trainer.HSCName = Console.ReadLine();
                    return "TSignUp";
                case "11":
                    Console.WriteLine("Enter HigherSec School Year of Passing");
                    trainer.HSCPYear = Console.ReadLine();
                    return "TSignUp";
                case "12":
                    Console.WriteLine("Enter HigherSec School Stream");
                    trainer.HSCStream = Console.ReadLine();
                    return "TSignUp";
                case "13":
                    Console.WriteLine("Enter High School Name");
                    trainer.HSName = Console.ReadLine();
                    return "TSignUp";
                case "14":
                    Console.WriteLine("Enter High School Year of Passing");
                    trainer.HSPYear = Console.ReadLine();
                    return "TSignUp";
                case "15":
                    Console.WriteLine("Enter Last Company Name");
                    trainer.LastCompany = Console.ReadLine();
                    return "TSignUp";
                case "16":
                    Console.WriteLine("Enter total experience in years");
                    trainer.TotalExp = Convert.ToInt32(Console.ReadLine());
                    return "TSignUp";
                case "17":
                    Console.WriteLine("Enter your Primary Skill");
                    trainer.Skill1 = Console.ReadLine();
                    return "TSignUp";
                case "18":
                    Console.WriteLine("Enter your Secondary Skill");
                    trainer.Skill2 = Console.ReadLine();
                    return "TSignUp";
                case "19":
                    Console.WriteLine("Enter your Tertiary Skill");
                    trainer.Skill3 = Console.ReadLine();
                    return "TSignUp";
                case "20":
                    Console.WriteLine("Enter your Quaternary Skill");
                    trainer.Skill4 = Console.ReadLine();
                    return "TSignUp";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TSignUp";

            }
        }
    }
}
