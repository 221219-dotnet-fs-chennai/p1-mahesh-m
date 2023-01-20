using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TUpdate : TSignUp, IMenu
    {
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");
        Dictionary<string, string> comp = trainer.GetCompany();

        IRepo repo = new SqlRepo(s[0], s[1]);
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

            Console.WriteLine("[1] Phone No." + "                            - " + trainer.PhoneNo);
            Console.WriteLine("[2] City" + "                                 - " + trainer.City);
            Console.WriteLine();


            Console.WriteLine("UG Details");
            Console.WriteLine("=============");
            Console.WriteLine();


            Console.WriteLine("[3] Bachelor's College Name" + "              - " + trainer.UGCName);
            Console.WriteLine("[4] Bachelor's Year of Passing" + "           - " + trainer.UGPYear);
            Console.WriteLine("[5] Bachelor's Degree" + "                    - " + trainer.UGDegree);
            Console.WriteLine("[6] Bachelor's Specializaiton" + "            - " + trainer.UGDept);
            Console.WriteLine();


            Console.WriteLine("Higher Secondary School Details");
            Console.WriteLine("==================================");
            Console.WriteLine();


            Console.WriteLine("[7] HigherSecSchool Name" + "                - " + trainer.HSCName);
            Console.WriteLine("[8] HigherSecSchool Year of Passing" + "     - " + trainer.HSCPYear);
            Console.WriteLine("[9] HigherSecSchool Stream" + "              - " + trainer.HSCStream);
            Console.WriteLine();



            Console.WriteLine("High School Details");
            Console.WriteLine("======================");
            Console.WriteLine();


            Console.WriteLine("[10] HighSchool Name" + "                     - " + trainer.HSName);
            Console.WriteLine("[11] HighSchool Year of Passing" + "          - " + trainer.HSPYear);
            Console.WriteLine();


            Console.WriteLine("Experience Details");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Console.WriteLine("[12] Company Details" + "                     - ");
            foreach (var e in comp)
            {
                Console.WriteLine("          ---------------------------");
                Console.WriteLine("            " + e.Key + "        |          " + e.Value + "    ");
                Console.WriteLine("          ---------------------------");
            }


            Console.WriteLine("Skill set");
            Console.WriteLine("============");
            Console.WriteLine();


            Console.WriteLine("[13] Primary Skill" + "                       - " + trainer.Skill1);
            Console.WriteLine("[14] Secondary Skill" + "                     - " + trainer.Skill2);
            Console.WriteLine("[15] Tertiary Skill" + "                      - " + trainer.Skill3);
            Console.WriteLine("[16] Quaternary Skill" + "                    - " + trainer.Skill4);
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
            String[] arr = trainer.Email.Split("@");
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
                    if (repo.IsExist(str, "phoneNo"))
                    {
                        Console.WriteLine("Phone No. is Associated with another account. Try add different phone number!");
                        Console.ReadLine();



                        return "TSignUp";

                    }
                    else
                    {

                        trainer.PhoneNo = str;
                        repo.UpdateATrainer(trainer.PhoneNo, "phoneNo", "trainers", userId);
                        Log.Information("Trainer updated his/her phone no.");
                        return "Profile";

                    }



                    


                case "2":
                    Console.WriteLine("Enter New City");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("City name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    trainer.City = str;
                    repo.UpdateATrainer(trainer.City, "city", "trainers", userId);
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
                    trainer.UGCName = str;
                    repo.UpdateATrainer(trainer.UGCName, "collegeName", "colleg_ug", userId);
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
                    trainer.UGPYear = str;

                    repo.UpdateATrainer(trainer.UGPYear, "yearpassed", "college_ug", userId);
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
                    trainer.UGDegree = str;
                    repo.UpdateATrainer(trainer.UGDegree, "degree", "college_ug", userId);
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
                    trainer.UGDept = str;
                    repo.UpdateATrainer(trainer.UGDept, "branch", "college_ug", userId);
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
                    trainer.HSCName = str;
                    repo.UpdateATrainer(trainer.HSCName, "Schoolname", "highsec", userId);
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
                    trainer.HSCPYear = str;
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
                    trainer.HSCStream = str;
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
                    trainer.HSName = str;
                    repo.UpdateATrainer(trainer.HSName, "schoolname", "highschool", userId);
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
                    trainer.HSPYear = str;
                    repo.UpdateATrainer(trainer.HSPYear, "yearpassed", "highschool", userId);
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
                    repo.UpdateCompanies(newC,exp, userId);
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
                    trainer.Skill1 = str;
                    repo.UpdateATrainer(trainer.Skill1, "skill_1", "Skills", userId);
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
                    trainer.Skill2 = str;
                    repo.UpdateATrainer(trainer.Skill2, "skill_2", "Skills", userId);
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
                    trainer.Skill3 = str;
                    repo.UpdateATrainer(trainer.Skill3, "skill_3", "Skills", userId);
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
                    trainer.Skill4 = str;
                    repo.UpdateATrainer(trainer.Skill4, "skill_4", "Skills", userId);
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
