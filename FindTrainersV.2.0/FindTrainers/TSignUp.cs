using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;

using EntityFramework;
//using EntityFramework.newEntities;
using Models;
using BusinessLogic;
using System.ComponentModel.DataAnnotations;

namespace FindTrainers
{
    internal class TSignUp : IMenu
    {
        BusinessLogic.IValidator val = new BusinessLogic.Validation();

        internal static Models.Trainer tr = new Models.Trainer();
        internal static Models.Skill sk = new Models.Skill();
        internal static Models.HighSchool hs = new Models.HighSchool();
        internal static Models.HighSec hsc = new Models.HighSec();
        internal static Models.CollegeUg cug = new Models.CollegeUg();
        internal static Models.Company com = new Models.Company();
        internal static List<Models.Company> companies = new List<Models.Company>();


        public TSignUp()
        {


        }
        
        public TSignUp(Models.Trainer tra, Models.HighSchool hsl, Models.HighSec hscl, List<Models.Company> cmp, Models.Skill sks, Models.CollegeUg col)
        {
            tr = tra;
            hs = hsl;
            hsc = hscl;
            companies = cmp;
            sk = sks;
            cug = col;
        }



        BusinessLogic.IRepo repo = new BusinessLogic.EFRepo();



        public void Display()

        {

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------- Sign Up  -------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++PRESS THE RESPECTIVE NOS. TO GIVE RESPECTIVE INPUTS++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Controls");
            Console.WriteLine("===========");
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Save");
            Console.WriteLine();


            Console.WriteLine("Basic Details");
            Console.WriteLine("=================");
            Console.WriteLine();


            Console.WriteLine("[2] First Name" + "                           - " + tr.FirstName);
            Console.WriteLine("[3] Last Name" + "                            - " + tr.LastName);
            Console.WriteLine("[4] Email ID" + "                             - " + tr.Email);
            Console.WriteLine("[5] Phone No." + "                            - " + tr.PhoneNo);
            Console.WriteLine("[6] City" + "                                   - " + tr.City);
            Console.WriteLine();

            Log.Logger.Information("Trainer basic details entered");


            Console.WriteLine("UG Details");
            Console.WriteLine("=============");
            Console.WriteLine();


            Console.WriteLine("[7] Bachelor's College Name" + "              - " + cug.CollegeName);
            Console.WriteLine("[8] Bachelor's Year of Passing" + "           - " + cug.YearPassed);
            Console.WriteLine("[9] Bachelor's Degree" + "                    - " + cug.Degree);
            Console.WriteLine("[10] Bachelor's Specializaiton" + "            - " + cug.Branch);
            Console.WriteLine();

            Log.Logger.Information("Trainer College Details entered");

            Console.WriteLine("Higher Secondary School Details");
            Console.WriteLine("==================================");
            Console.WriteLine();


            Console.WriteLine("[11] HigherSecSchool Name" + "                - " + hsc.SchoolName);
            Console.WriteLine("[12] HigherSecSchool Year of Passing" + "     - " + hsc.YearPassed);
            Console.WriteLine("[13] HigherSecSchool Stream" + "              - " + hsc.Course);
            Console.WriteLine();



            Console.WriteLine("High School Details");
            Console.WriteLine("======================");
            Console.WriteLine();


            Console.WriteLine("[14] HighSchool Name" + "                     - " + hs.SchoolName);
            Console.WriteLine("[15] HighSchool Year of Passing" + "          - " + hs.YearPassed);
            Console.WriteLine();

            Log.Logger.Information("Trainer School Details entered");

            Console.WriteLine("Experience Details");
            Console.WriteLine("=====================");
            Console.WriteLine();

            Console.WriteLine("[16] Company Details and Experience in years" + "                      ");
            Console.WriteLine();

            if (companies.Count > 0)
            {
                var table = new ConsoleTable("Companies", "Experience in Years");
                foreach (var e in companies)
                {

                    table.AddRow(e.LastCompanyName, e.TotalExp);

                }
                table.Write(Format.MarkDown);
            }


            Console.WriteLine();
            Console.WriteLine();

            Log.Logger.Information("Trainer Experience details added");

            Console.WriteLine("Skill set");
            Console.WriteLine("============");
            Console.WriteLine();


            Console.WriteLine("[17] Primary Skill" + "                       - " + sk.Skill1);
            Console.WriteLine("[18] Secondary Skill" + "                     - " + sk.Skill2);
            Console.WriteLine("[19] Tertiary Skill" + "                      - " + sk.Skill3);
            Console.WriteLine("[20] Quaternary Skill" + "                    - " + sk.Skill4);


            Console.WriteLine();
            Log.Logger.Information("Trainer Skillset has been entered!");

            Console.WriteLine();

            Console.WriteLine("[21] Password");

        }


        public string UserChoice()
        {


            string? userInput = Console.ReadLine();
            Console.WriteLine();

            switch (userInput)
            {
                case "0":
                    return "Trainer";
                case "1":
                    repo.InsertTrainers(tr, sk, hsc, hs, companies, cug);
                    return "Profile";


                case "2":
                    Console.WriteLine("Enter First Name");
                    string? str = Console.ReadLine();
                    bool regVal = val.Validator(str, "nameRegex", "First Name");
                    if (regVal)
                    {
                        tr.FirstName = str;
                    }
                    return "TSignUp";



                case "3":
                    Console.WriteLine("Enter Last Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Last Name");
                    if (regVal)
                    {
                        tr.LastName = str;
                    }

                    return "TSignUp";


                case "4":
                    Console.WriteLine("Enter Email ID");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "emailRegex", "email");
                    if (regVal)
                    {
                        if (!repo.IsExist(str, "PhoneNo"))
                        {
                            tr.PhoneNo = str;
                            tr.Email = str;
                            tr.TrainerId = str.Split("@")[0];
                            hs.TrainerId = tr.TrainerId;
                            hsc.TrainerId = tr.TrainerId;
                            cug.TrainerId = tr.TrainerId;
                            sk.TrainerId = tr.TrainerId;
                            return "TSignUp";
                        }
                        Console.WriteLine("Email Id is associated with another account!! try with new Email");
                        Console.ReadLine();
            
                    }
                    return "TSignUp";

                case "5":
                    Console.WriteLine("Enter Phone No.");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "phoneRegex", "email");
                    if (regVal)
                    {
                        if(!repo.IsExist(str, "PhoneNo"))
                        {
                            tr.PhoneNo = str;
                                return "TSignUp";
                        }
                        Console.WriteLine("Phone No. is associated with another account!! try with new Phone number");
                        Console.ReadLine();
                    }
                    return "TSignUp";



                case "6":
                    Console.WriteLine("Enter City name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "City");
                    if (regVal)
                    {
                        tr.City = str;
                    }
                    return "TSignUp";

                case "7":
                    Console.WriteLine("Enter Bachelor's College Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "College Name");
                    if (regVal)
                    {
                        cug.CollegeName = str;
                    }
                    return "TSignUp";

                case "8":
                    Console.WriteLine("Enter Bachelor's Year of Passing");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        cug.YearPassed = str;
                    }
                    return "TSignUp";


                case "9":
                    Console.WriteLine("Enter Bachelor's Degree (Format eg: B.Tech,B.A,B.Sc");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "degreeRegex", "College Name");
                    if (regVal)
                    {
                        cug.Degree = str;
                    }
                    return "TSignUp";


                case "10":
                    Console.WriteLine("Enter Bachelor's Specialization");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Specialization");
                    if (regVal)
                    {
                        cug.Branch = str;
                    }

                    return "TSignUp";


                case "11":
                    Console.WriteLine("Enter HigherSec School Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "School Name");
                    if (regVal)
                    {
                        hsc.SchoolName = str;
                    }

                    return "TSignUp";


                case "12":
                    Console.WriteLine("Enter HigherSec School Year of Passing");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        hsc.YearPassed = str;
                    }

                    return "TSignUp";


                case "13":
                    Console.WriteLine("Enter HigherSec School Stream");

                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Stream");
                    if (regVal)
                    {
                        hsc.Course = str;
                    }
                 

                    return "TSignUp";


                case "14":
                    Console.WriteLine("Enter High School Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "School Name");
                    if (regVal)
                    {
                        hs.SchoolName = str;
                    }
                    return "TSignUp";


                case "15":
                    Console.WriteLine("Enter High School Year of Passing");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        hs.YearPassed = str;
                    }
                    return "TSignUp";


                case "16":
                    Console.WriteLine("Enter Company Name");
                    string compny = Console.ReadLine();

                    regVal = val.Validator(compny, "nameRegex", "Company name");
                    string? experience;
                    int e;
                    if (regVal)
                    {

                        Console.WriteLine("Enter your experience in years");
                        experience = Console.ReadLine();
                        if (experience.Length > 0)
                        {

                            e = Convert.ToInt32(experience);
                            while (e < 1 || e > 30)
                            {
                                Console.WriteLine("Give correct experience information");
                                experience = Console.ReadLine();
                                while (experience.Length <= 0)
                                {
                                    Console.WriteLine("Experience can't be null! Re enter the experience in years");
                                    experience = Console.ReadLine();
                                }
                                e = Convert.ToInt32(experience);
                            }

                  
                            companies.Add(new Models.Company()
                            {
                                TrainerId = tr.Email.Split("@")[0],
                                LastCompanyName = compny,
                                TotalExp = e
                            });

                            Console.WriteLine("Do you have any other experience? Type (Y/N)");

                            string c = Console.ReadLine();
                            while (c == "Y" || c == "y")
                            {
                                Console.WriteLine("Enter Company Name");
                                compny = Console.ReadLine();
                                regVal = val.Validator(compny, "nameRegex", "Company name");

                                if (regVal)
                                {

                                    Console.WriteLine("Enter your experience in years");
                                    experience = Console.ReadLine();
                                    if (experience.Length > 0)
                                    {
                                        e = Convert.ToInt32(experience);
                                        while (e < 1 || e > 30)
                                        {
                                            Console.WriteLine("Give correct experience information");
                                            experience = Console.ReadLine();
                                            while (experience.Length <= 0)
                                            {
                                                Console.WriteLine("Experience can't be null! Re enter the experience in years");
                                                experience = Console.ReadLine();
                                            }
                                            e = Convert.ToInt32(experience);
                                        }


                                        companies.Add(new Models.Company()
                                        {
                                            TrainerId = tr.Email.Split("@")[0],
                                            LastCompanyName = compny,
                                            TotalExp = e
                                        });

                                    }
                                    else
                                    {
                                        Console.WriteLine("Experience can't be null!");
                                        Console.ReadLine();

                                    }


                                }


                                Console.WriteLine("Do you have any other experience? Type (Y/N)");
                                c = Console.ReadLine();


                            }

                        }
                        else
                        {
                            Console.WriteLine("Experience can't be null!");
                            Console.ReadLine();
                        }


                    }


                    return "TSignUp";

                case "17":
                    Console.WriteLine("Enter your Primary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill1 = str;
                    }
                 

                    return "TSignUp";
                case "18":
                    Console.WriteLine("Enter your Secondary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill2 = str;
                    }

                    return "TSignUp";
                case "19":
                    Console.WriteLine("Enter your Tertiary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill3 = str;
                    }


                    return "TSignUp";
                case "20":
                    Console.WriteLine("Enter your Quaternary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill4 = str;
                    }

                    return "TSignUp";
                case "21":
                    Console.WriteLine("Enter your Password");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "passwordRegex", "password");
                    if (regVal)
                    {
                        Console.WriteLine("Retype password to Confirm Password");
                        string cPass = Console.ReadLine();
                        while (!str.Equals(cPass))
                        {
                            Console.WriteLine("Passwords are not matching! Re type confirm password! ");
                            cPass = Console.ReadLine();
                        }
                        tr.Password = str;
                    }
                  

                    return "TSignUp";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TSignUp";

            }
        }


    }
}
