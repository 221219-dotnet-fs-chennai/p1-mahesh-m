using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TLogIn : IMenu
    {
        IRepo repo = new SqlRepo();
        public void Display()
        {
            Console.WriteLine($"<-------------------------- LOGIN PAGE ----------------------------->");
            Console.WriteLine();
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Continue with log In");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Trainer";
                case "1":
                    repo.Login();
                    return "TLogIn";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TLogIn";




            }
        }
    }
}
