using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleTables;
using BusinessLogic;

namespace FindTrainers
{
    internal class TUpdate : TSignUp, IMenu
    {
       
       BusinessLogic.Validation val=new Validation();

        BusinessLogic.IRepo repo=new BusinessLogic.EFRepo();
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
                    bool regVal = val.Validator(str, "phoneRegex", "email");
               
                    if (regVal)
                    {
                        if (!repo.IsExist(str, "PhoneNo"))
                        {
                            tr.PhoneNo = str;
                            repo.UpdateATrainer(tr.PhoneNo, "phoneNo", "trainers", userId);
                            Log.Information("Trainer updated his/her phone no.");
                            return "Profile";
                        }
                        Console.WriteLine("Phone No. is associated with another account!! try with new Phone number");
                        Console.ReadLine();
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


                    return "Profile";






                case "2":
                    Console.WriteLine("Enter New City");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "City");
                    if (regVal)
                    {
                        tr.City = str;
                        repo.UpdateATrainer(tr.City, "city", "trainers", userId);
                        Log.Information("Trainer updated his/her City.");
                    }

                    return "Profile";


                case "3":
                    Console.WriteLine("Enter New Bachelor's College Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "College Name");
                    if (regVal)
                    {
                        cug.CollegeName = str;
                        repo.UpdateATrainer(cug.CollegeName, "collegeName", "college_ug", userId);
                        Log.Information("Trainer update his/her College Name");
                    }
                    Console.ReadLine();
                    return "Profile";



                case "4":
                    Console.WriteLine("Enter New Bachelor's Year of Passing");
                    str = Console.ReadLine();
                     regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        cug.YearPassed = str;
                        repo.UpdateATrainer(cug.YearPassed, "yearpassed", "college_ug", userId);
                        Log.Information("user updates his/her UG year");
                    }

                    Console.ReadLine();
                    return "Profile";



                case "5":
                    Console.WriteLine("Enter New Bachelor's Degree");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "degreeRegex", "College Name");
                    if (regVal)
                    {
                        cug.Degree = str;
                        repo.UpdateATrainer(cug.Degree, "degree", "college_ug", userId);
                        Log.Information("user updates his/her Bachelors degree");
                    }
                    Console.ReadLine();
                 
                    return "Profile";



                case "6":
                    Console.WriteLine("Enter New Bachelor's Specialization");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Specialization");
                    if (regVal)
                    {
                        cug.Branch = str;

                        repo.UpdateATrainer(cug.Branch, "branch", "college_ug", userId);
                        Log.Information("user updates his/her Bachelors specialization");
                    }
                    Console.ReadLine();
                    return "Profile";


                case "7":
                    Console.WriteLine("Enter New HigherSec School Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "School Name");
                    if (regVal)
                    {
                        hsc.SchoolName = str;
                        repo.UpdateATrainer(hsc.SchoolName, "schoolname", "highsec", userId);
                        Log.Information("user updates his/her HSC school name");
                    }
                    Console.ReadLine();
                    return "Profile";


                case "8":
                    Console.WriteLine("Enter New HigherSec School Year of Passing");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        hsc.YearPassed = str;
                        repo.UpdateATrainer(hsc.YearPassed, "yearpassed", "highsec", userId);
                        Log.Information("user updates his/her HSCP year");
                    }
                    Console.ReadLine();
                    return "Profile";


                case "9":
                    Console.WriteLine("Enter New HigherSec School Stream");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Stream");
                    if (regVal)
                    {
                        hsc.Course = str;
                        repo.UpdateATrainer(hsc.Course, "course", "highsec", userId);
                        Log.Information("user updates his/her HSC stream");
                    }
                    Console.ReadLine();

                    return "Profile";


                case "10":
                    Console.WriteLine("Enter New High School Name");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Stream");
                    if (regVal)
                    {
                        hs.SchoolName = str;
                        repo.UpdateATrainer(hs.SchoolName, "schoolname", "highschool", userId);
                        Log.Information("User updates his/her HS Name");
                    }
                    Console.ReadLine();
                    return "Profile";


                case "11":
                    Console.WriteLine("Enter New High School Year of Passing");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "yearRegex", "year of passing");
                    if (regVal)
                    {
                        hs.YearPassed = str;
                        repo.UpdateATrainer(hs.YearPassed, "yearpassed", "highschool", userId);
                        Log.Information("user updates his/her HS Year of Passing");
                    }
                    Console.ReadLine();

                    return "Profile";


                case "12":
                 
                    Console.WriteLine("Enter the new company name");
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


                        }
                        repo.UpdateCompanies(compny, experience, userId);
                        Log.Information("User updates his/her Experience details");
                    }
                    Console.ReadLine();

                    return "Profile";
                case "13":
                    Console.WriteLine("Enter New your Primary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill1 = str;
                        repo.UpdateATrainer(sk.Skill1, "skill_1", "Skills", userId);
                        Log.Information("User updates his/her Skill Details");
                    }

                    Console.ReadLine();
                    return "Profile";

                case "14":
                    Console.WriteLine("Enter New your Secondary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill2 = str;
                        repo.UpdateATrainer(sk.Skill2, "skill_2", "Skills", userId);
                        Log.Information("User updates his/her Skill Details");
                    }

                    Console.ReadLine();
                    return "Profile";

                case "15":
                    Console.WriteLine("Enter New your Tertiary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill3 = str;
                        repo.UpdateATrainer(sk.Skill3, "skill_3", "Skills", userId);
                        Log.Information("User updates his/her Skill Details");
                    }

                    Console.ReadLine();
                    return "Profile";
                case "16":
                    Console.WriteLine("Enter New your Quaternary Skill");
                    str = Console.ReadLine();
                    regVal = val.Validator(str, "nameRegex", "Skill");
                    if (regVal)
                    {
                        sk.Skill4 = str;
                        repo.UpdateATrainer(sk.Skill4, "skill_4", "Skills", userId);
                        Log.Information("User updates his/her Skill Details");
                    }
                    Console.ReadLine();
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
