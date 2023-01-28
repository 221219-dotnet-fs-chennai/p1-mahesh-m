using ConsoleTables;
using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;

namespace FindTrainers
{
    internal class TUpdate : TSignUp, IMenu
    {
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");
        Dictionary<string, string> comp = trainer.GetCompany();

        EntityFramework.IRepo repo=new EntityFramework.EFRepo();
        public new void Display()
        {
         
           
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------- Update Page  -------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++PRESS THE RESPECTIVE NOS. TO GIVE RESPECTIVE INPUTS++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Controls");
            Console.WriteLine("===========");
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine();


            Console.WriteLine("Basic Details");
            Console.WriteLine("=================");
            Console.WriteLine();

            Console.WriteLine("[1] Phone No." + "                            - " + tr.PhoneNo);
            Console.WriteLine("[2] City" + "                                 - " + tr.City);
            Console.WriteLine();


            Console.WriteLine("UG Details");
            Console.WriteLine("=============");
            Console.WriteLine();


            Console.WriteLine("[3] Bachelor's College Name" + "              - " + cug.CollegeName);
            Console.WriteLine("[4] Bachelor's Year of Passing" + "           - " + cug.YearPassed);
            Console.WriteLine("[5] Bachelor's Degree" + "                    - " + cug.Degree);
            Console.WriteLine("[6] Bachelor's Specializaiton" + "            - " + cug.Branch);
            Console.WriteLine();


            Console.WriteLine("Higher Secondary School Details");
            Console.WriteLine("==================================");
            Console.WriteLine();


            Console.WriteLine("[7] HigherSecSchool Name" + "                - " + hsc.SchoolName);
            Console.WriteLine("[8] HigherSecSchool Year of Passing" + "     - " + hsc.YearPassed);
            Console.WriteLine("[9] HigherSecSchool Stream" + "              - " + hsc.Course);
            Console.WriteLine();



            Console.WriteLine("High School Details");
            Console.WriteLine("======================");
            Console.WriteLine();


            Console.WriteLine("[10] HighSchool Name" + "                     - " + hs.SchoolName);
            Console.WriteLine("[11] HighSchool Year of Passing" + "          - " + hs.YearPassed);
            Console.WriteLine();


            Console.WriteLine("Experience Details");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Console.WriteLine("[12] Company Details and Experience in years" );
          


            Console.WriteLine();
            var table = new ConsoleTable("Companies", "Experience in Years");


            foreach (var e in companies)
            {
                table.AddRow(e.LastCompanyName, e.TotalExp);

            }
            table.Write(Format.MarkDown);
            Console.WriteLine();

            Console.WriteLine("Skill set");
            Console.WriteLine("============");
            Console.WriteLine();


            Console.WriteLine("[13] Primary Skill" + "                       - " + sk.Skill1);
            Console.WriteLine("[14] Secondary Skill" + "                     - " + sk.Skill2);
            Console.WriteLine("[15] Tertiary Skill" + "                      - " + sk.Skill3);
            Console.WriteLine("[16] Quaternary Skill" + "                    - " + sk.Skill4);
            Console.WriteLine();
            Console.WriteLine();
         
         
           

        }

        public new string UserChoice()
        {
            string? nameRegex = @"\w{3,50}";
            string? emailRegex = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-z]{2,6}$";
            string? phoneRegex = @"^[9876]\d{9}$";
            string? yearRegex = @"^\d{4}$";
            string? degreeRegex = @"^B\.\w{1,6}$";
            string? passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            String[] arr = tr.Email.Split("@");
            string userId = arr[0];
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Profile";

                case "1":
                    Console.WriteLine("Enter New Phone No.");
                    string str= Console.ReadLine();
                    while (!FormatChecker(str, phoneRegex))
                    {
                        Console.WriteLine("Phone No. format is invalid! Re-enter Phone No.");
                        str = Console.ReadLine();
                    }
                    //if (repo.IsExist(str, "phoneNo"))
                    //{
                    //    Console.WriteLine("Phone No. is Associated with another account. Try add different phone number!");
                    //    Console.ReadLine();



                    //    return "TUpdate";

                    //}
                    //else
                    //{

                       

                    //}
                    tr.PhoneNo = str;
                    repo.UpdateATrainer(tr.PhoneNo, "phoneNo", "trainers", userId);
                    Log.Information("Trainer updated his/her phone no.");
                    return "Profile";






                case "2":
                    Console.WriteLine("Enter New City");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("City name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    tr.City = str;
                    repo.UpdateATrainer(tr.City, "city", "trainers", userId);
                    Log.Information("Trainer updated his/her City.");
                    return "Profile";
                case "3":
                    Console.WriteLine("Enter New Bachelor's College Name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("College Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    cug.CollegeName = str;
                    repo.UpdateATrainer(cug.CollegeName, "collegeName", "college_ug", userId);
                    Log.Information("Trainer update his/her College Name");
                    return "Profile";
                case "4":
                    Console.WriteLine("Enter New Bachelor's Year of Passing");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    cug.YearPassed= str;

                    repo.UpdateATrainer(cug.YearPassed, "yearpassed", "college_ug", userId);
                    Log.Information("user updates his/her UG year");
                    return "Profile";
                case "5":
                    Console.WriteLine("Enter New Bachelor's Degree");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, degreeRegex))
                    {
                        Console.WriteLine("Please use the correct format for degree");
                        str = Console.ReadLine();
                    }
                    cug.Degree= str;
                    repo.UpdateATrainer(cug.Degree, "degree", "college_ug", userId);
                    Log.Information("user updates his/her Bachelors degree");
                    return "Profile";
                case "6":
                    Console.WriteLine("Enter New Bachelor's Specialization");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Specializtion should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    cug.Branch= str;
                    repo.UpdateATrainer(cug.Branch, "branch", "college_ug", userId);
                    Log.Information("user updates his/her Bachelors specialization");
                    return "Profile";
                case "7":
                    Console.WriteLine("Enter New HigherSec School Name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Higher Secondary School Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    hsc.SchoolName= str;
                    repo.UpdateATrainer(hsc.SchoolName, "schoolname", "highsec", userId);
                    Log.Information("user updates his/her HSC school name");
                    return "Profile";
                case "8":
                    Console.WriteLine("Enter New HigherSec School Year of Passing");
                    repo.UpdateATrainer(trainer.HSCPYear, "yearpassed", "highsec", userId);
                    str = Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    hsc.YearPassed= str;
                    repo.UpdateATrainer(hsc.YearPassed, "yearpassed", "highsec", userId);
                    Log.Information("user updates his/her HSCP year");
                    return "Profile";
                case "9":
                    Console.WriteLine("Enter New HigherSec School Stream");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Higher Secondary Stream should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    hsc.Course=str;
                    repo.UpdateATrainer(trainer.HSCStream, "course", "highsec", userId);
                    Log.Information("user updates his/her HSC stream");
                    return "Profile";
                case "10":
                    Console.WriteLine("Enter New High School Name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("High School Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    hs.SchoolName=str;
                    repo.UpdateATrainer(hs.SchoolName, "schoolname", "highschool", userId);
                    Log.Information("User updates his/her HS Name");
                    return "Profile";
                case "11":
                    Console.WriteLine("Enter New High School Year of Passing");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    hs.YearPassed = str;
                    repo.UpdateATrainer(hs.YearPassed, "yearpassed", "highschool", userId);
                    Log.Information("user updates his/her HS Year of Passing");
                    return "Profile";
                case "12":
                 
                    Console.WriteLine("Enter the new company name");
                    string newC = Console.ReadLine();

                    while (!FormatChecker(newC, nameRegex))
                    {
                        Console.WriteLine("Company name should be 3 to 50 characters long");
                        newC = Console.ReadLine();
                    }

                    Console.WriteLine("Enter the experience to that company");
                    string exp= Console.ReadLine();
                    int e = Convert.ToInt32(exp);
                    while (e < 1 || e > 30)
                    {
                        Console.WriteLine("Give correct experience information");
                        exp = Console.ReadLine();
                    }
                    trainer.SetCompany(newC, exp);
                    //repo.UpdateCompanies(newC,exp, userId);
                    Log.Information("User updates his/her Experience details");
                    return "Profile";
                case "13":
                    Console.WriteLine("Enter New your Primary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Primary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    sk.Skill1= str;
                    repo.UpdateATrainer(sk.Skill1, "skill_1", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "14":
                    Console.WriteLine("Enter New your Secondary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Primary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    sk.Skill2 = str;
                    repo.UpdateATrainer(sk.Skill2, "skill_2", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "15":
                    Console.WriteLine("Enter New your Tertiary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Primary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    sk.Skill3 = str;
                    repo.UpdateATrainer(sk.Skill3, "skill_3", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";
                case "16":
                    Console.WriteLine("Enter New your Quaternary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Primary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    sk.Skill4 = str;
                    repo.UpdateATrainer(sk.Skill4, "skill_4", "Skills", userId);
                    Log.Information("User updates his/her Skill Details");
                    return "Profile";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Profile";
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
