using ConsoleTables;
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


        //IRepo repo = new SqlRepo(s[0], s[1]);
        BusinessLogic.IRepo repo =new BusinessLogic.EFRepo();
        public void Display()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] View ll Trainers");
            Console.WriteLine("[2] View By Filter");
    
        }

        public string UserChoice()
        {
            string userInput=Console.ReadLine();

            switch(userInput)
            {
                case"0":
                    return "Menu";
                case"1":
                    Console.Clear();
                    var listOfTrainers=repo.GetAll();

                    var table = new ConsoleTable("Nos","Name","Primary Skill", "Phone No.","Email","Location");
                    //Console.WriteLine("==========================");
                    //Console.WriteLine(listOfTrainers.Count);
                    int Count = 1;
                    Console.WriteLine("----------------------------------------------Trainers' List------------------------------------------------------------");

                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var t in listOfTrainers)
                    {
                        table.AddRow(Count,t.FirstName+" "+t.LastName,t.Skill1,t.PhoneNo,t.Email,t.City);
                       

                        Count++;
                    }
                    table.Write(Format.Alternative);
                    Console.WriteLine();    
            





                    Console.ReadLine();

              
                    return "User";
                
                case"2":
                    return "Filter";




                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "User";
            }
        }
    }
}
