using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class UFilter : IMenu
    { BusinessLogic.ILogic repo = new BusinessLogic.Logic();
        public void Display()
        {
            Console.WriteLine("Hello User, Choose your filter!");

            Console.WriteLine();
            Console.WriteLine("Available Filters");
            Console.WriteLine();
            Console.WriteLine("[1] Filter by skill");
            Console.WriteLine("[2] Filter by Location");
        }

        public string UserChoice()
        {
            Console.WriteLine("Enter your choice:");
            string userInput=Console.ReadLine();

            switch (userInput) {

                case "1":
                    Console.WriteLine("Enter the skill");
                    string ? skill=Console.ReadLine();
                    var accs= repo.TrainersBySkill(skill);
                    int count = 1;
                    Console.WriteLine();
                    Console.Clear();

                    Console.WriteLine($"Trainers who are specialized in {skill}:");
                    Console.WriteLine();
                    var table = new ConsoleTable("Nos", "Name", "Primary Skill", "Phone No.", "Email", "Location");
                    if (accs.ToList().Count()>0)
                    {   
                        foreach(var e in accs)
                        {
                            table.AddRow(count, e.FirstName + " " +e.LastName, e.Skill1, e.PhoneNo, e.Email, e.City);


                            count++;
                        }
                    }
                    table.Write(Format.Alternative);
                    Console.WriteLine();

                    Console.ReadLine();
                    count= 0;
                    return "User";


                case "2":
                    Console.WriteLine("Enter the City");
                    string? City = Console.ReadLine();
                     accs = repo.TrainersByLocation(City);
                     count = 1;
                    Console.WriteLine();
                    Console.Clear();

                    Console.WriteLine($"Trainers who are in {City}:");
                    Console.WriteLine();
                    table = new ConsoleTable("Nos", "Name", "Primary Skill", "Phone No.", "Email", "Location");
                    if (accs.ToList().Count() > 0)
                    {
                        foreach (var e in accs)
                        {
                            table.AddRow(count, e.FirstName + " " + e.LastName, e.Skill1, e.PhoneNo, e.Email, e.City);


                            count++;
                        }
                    }
                    table.Write(Format.Alternative);
                    Console.WriteLine();

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
