using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validation:IValidator
    {
        string? nameRegex = @"\w{3,50}";
        string? emailRegex = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-z]{2,6}$";
        string? phoneRegex = @"^[9876]\d{9}$";
        string? yearRegex = @"^\d{4}$";
        string? degreeRegex = @"^B\.\w{1,6}$";
        string? passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";


        public bool Validator(string str,string type,string field)
        {
            switch (type)
            {
                case "nameRegex":
                     if (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine($"{field} should be 3 to 50 characters long! Retry !!");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
            
                case "emailRegex":
                    if (!FormatChecker(str, emailRegex))
                    {
                        Console.WriteLine("Email format is invalid! Re-enter email");
                        //Console.ReadLine();
                        return false;
                    }
                    return true;
                case "phoneRegex":
                    if (!FormatChecker(str, phoneRegex))
                    {
                        Console.WriteLine("Phone No. format is invalid! Re-enter Phone No.");
                        //Console.ReadLine();
                        return false;
                    }
                    return true;
                case "yearRegex":
                    if(!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                case "degreeRegex":
                    if (!FormatChecker(str, degreeRegex))
                    {
                        Console.WriteLine("Please use the correct format for degree");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                case "passwordRegex":
                    if (!FormatChecker(str, passwordRegex))
                    {
                        Console.WriteLine("Password min 8 characters, atleast 1 lower case,1 upper case,1 number");
                        Console.ReadLine();
                        return false;
                    }
                    return true;

                default:
                    return false;

            }
        }


        public bool FormatChecker(string str, string regex)
        {
            Regex r = new Regex(regex);
            if (r.IsMatch(str))
            {
                return true;

            }
            else
            {
                return false;
            }


        }


    }
}
