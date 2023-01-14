using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class Menu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Hello Welcome to Find Trainers!");
            Console.WriteLine("Are you a Trainer or Learner?");
            Console.WriteLine("[2] Continue as User");
            Console.WriteLine("[1] Continue as Trainer");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Trainer";
                case "2":
                    return "User";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Menu";
            }

            return "hello";
        }
    }
}