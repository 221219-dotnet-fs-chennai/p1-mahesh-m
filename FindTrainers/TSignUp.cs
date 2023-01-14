using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT_UIConsole
{
    internal class TSignUp : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Save");
            Console.WriteLine("[2] First Name");
            Console.WriteLine("[3] Last Name");
            Console.WriteLine("[4] Email ID");
            Console.WriteLine("[5] Phone No.");
            Console.WriteLine("[6] Bachelor's College Name");
            Console.WriteLine("[7] Bachelor's Year of Passing");
            Console.WriteLine("[8] Bachelor's Degree");
            Console.WriteLine("[9] Bachelor's Specializaiton");
            Console.WriteLine("[10] HigherSecSchool Name");
            Console.WriteLine("[11] HigherSecSchool Year of Passing");
            Console.WriteLine("[12] HigherSecSchool Stream");
            Console.WriteLine("[13] HighSchool Name");
            Console.WriteLine("[14] HighSchool Year of Passing");
            Console.WriteLine("[15] Last Company Worked");
            Console.WriteLine("[16] Total Experience in Years");
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
                    return "TSignUp";
                case"3":
                    Console.WriteLine("Enter Last Name");
                    return "TSignUp";
                case"4":
                    Console.WriteLine("Enter Email ID");
                    return "TSignUp";
                case "5":
                    Console.WriteLine("Enter Phone No.");
                    return "TSignup";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TSignUp";

            }
        }
    }
}
