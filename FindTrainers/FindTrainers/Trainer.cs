using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class Trainer : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Hello Trainer!");
            Console.WriteLine("[2] LogIn");
            Console.WriteLine("[1] SignUp");
            Console.WriteLine("[0] Go back :)");


        }

        public string UserChoice()
        {
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Menu";
                case "1":
                    return "TSignUp";
                case "2":
                    return "LogIn";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Trainer";
            }
        }
    }
}
