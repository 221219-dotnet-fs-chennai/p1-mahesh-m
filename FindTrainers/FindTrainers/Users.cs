using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class Users : IMenu
    {

        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");


        IRepo repo = new SqlRepo(s[0], s[1]);
        public void Display()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] View Trainers");
    
        }

        public string UserChoice()
        {
            string userInput=Console.ReadLine();

            switch(userInput)
            {
                case"0":
                    return "Menu";
                case"1":
                    var listOfTrainers=repo.GetAll();

                    Console.WriteLine("==========================");
                    Console.WriteLine(listOfTrainers.Count);
                    foreach (var t in listOfTrainers)
                    {
                        Console.WriteLine(t.FName + " " + t.LName);
                        Console.WriteLine(t.Skill1);
                        Console.WriteLine(t.PhoneNo);
                        Console.WriteLine(t.Email);
                        Console.WriteLine();
                        Console.WriteLine("==========================");
                        

                    }
                    Console.ReadLine();

              
                    return "User";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "User";
            }
        }
    }
}
