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
                    Console.WriteLine("Enter email id");
                    string? email = Console.ReadLine();
                    bool res= repo.Login(email);
                    if (res)
                    {
                        TSignUp newTrainer = new TSignUp(repo.GetATrainer(email));
                        return "Profile";
                    }
                    else {
                        Console.WriteLine("Bad Credentials! Retry again");
                        return "TLogIn";
                    }
                    
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TLogIn";




            }
        }
    }
}
