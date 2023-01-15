using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datafile;
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
                    return "Profile";
                case "2":
                    return "Profile";
                case "3":
                    return "Profile";
                case "4":
                    return "Menu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return " Menu";

            }

        }
    }
}
