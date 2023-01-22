﻿using ConsoleTables;
using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TDelete : TSignUp, IMenu
    {
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");

        IRepo repo = new SqlRepo(s[0], s[1]);
        Dictionary<string, string> comp = trainer.GetCompany();

        public new void Display()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------- Update Page  -------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Controls");
            Console.WriteLine("===========");
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine();


            Console.WriteLine("Basic Details");
            Console.WriteLine("=================");
            Console.WriteLine();

            Console.WriteLine("[1] Phone No." + "                              - " + trainer.PhoneNo);
            Console.WriteLine("[2] City" + "                                   - " + trainer.City);
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
            var table = new ConsoleTable("Companies", "Experience in Years");


            foreach (var e in comp)
            {
                table.AddRow(e.Key, e.Value);

            }
            table.Write(Format.MarkDown);
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Skill set");
            Console.WriteLine("============");
            Console.WriteLine();


            Console.WriteLine("[13] Primary Skill" + "                       - " + trainer.Skill1);
            Console.WriteLine("[14] Secondary Skill" + "                     - " + trainer.Skill2);
            Console.WriteLine("[15] Tertiary Skill" + "                      - " + trainer.Skill3);
            Console.WriteLine("[16] Quaternary Skill" + "                    - " + trainer.Skill4);
            Console.WriteLine();
            Console.WriteLine();
        

            Console.WriteLine("[17] DELETE YOUR ACCOUNT !!!!!");
        }

        public new string UserChoice()
        {
            String[] arr = trainer.Email.Split("@");
            string userId = arr[0];
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Profile";
            

                case "1":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    string val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("","phoneNo", "trainers", userId);
                    }
                    trainer.PhoneNo = "";
                    Log.Information("Deletes phno");

                    return "Profile";

                case "2":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                     val  = Console.ReadLine();
                    if (val == "1")
                    {
                        repo.UpdateATrainer("","city", "trainers", userId);
                    }
                    trainer.City = "";
                    Log.Information("Deletes City");

                    return "Profile";
                case "3":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                     val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("","collegename", "college_ug", userId);
                    }
                    trainer.UGCName = "";
                    Log.Information("Deletes UGC name");
                    return "Profile";
                case "4":

                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                     val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "yearpassed", "college_ug", userId);
                    }
                    trainer.UGPYear="";
                    Log.Information("Deletes UGP year");
                    return "Profile";
                case "5":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "degree", "college_ug", userId);
                    }
                    trainer.UGDegree = "";
                    Log.Information("Deletes UG Degree");

                    return "Profile";
                case "6":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "branch", "college_ug", userId);
                    }
                    trainer.UGDept = "";
                    Log.Information("Deletes UG Dept");
                    return "Profile";
                case "7":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "Schoolname", "highsec", userId);
                    }

                    trainer.HSCName = "";
                    Log.Information("Deletes HSC Name");
               
                    return "Profile";
                case "8":
                   
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "yearpassed", "highsec", userId);
                    }

                    trainer.HSCPYear = "";
                    Log.Information("Deletes HSCP year");
                    return "Profile";
                case "9":
           
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "course", "highsec", userId);
                    }
                    trainer.HSCStream = "";
                    Log.Information("Deletes HSC stream");

                    return "Profile";
                case "10":
                   
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "schoolname", "highschool", userId);
                    }
                    trainer.HSName = "";
                    Log.Information("Deletes HS Name");

                    return "Profile";
                case "11":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "yearpassed", "highschool", userId);
                    }
                    trainer.HSPYear = "";
                    Log.Information("Deletes HSP year");
                    return "Profile";
                case "12":
                    Console.WriteLine("Enter the company name to delete the record");
                    string cname=Console.ReadLine();

                 

                    if (trainer.GetCompany().ContainsKey(cname))
                    {
                        Console.WriteLine("Are you sure?");
                        Console.WriteLine("[1] Proceed");
                        Console.WriteLine("[0] Abort");
                        val = Console.ReadLine();
                        if (val == "1")
                        {
                            //repo.DeleteCompanies(userId);
                            //trainer.GetCompany().Clear();
                            repo.DeleteSingleCompany(cname, userId);
                            trainer.GetCompany().Remove(cname);


                        }


                        
                    }
                    else
                    {
                        Console.WriteLine("Company not found (or) Type the Company name properly again");
                        Console.ReadLine();
                    }

                    Log.Information("Deletes Experience details");

                    return "Profile";
       
                case "13":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "skill_1", "Skills", userId);
                    }
                    trainer.Skill1 = "";
                    Log.Information("Deletes Skillset details");
                    return "Profile";
                case "14":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "skill_2", "Skills", userId);
                    }
                    trainer.Skill2 = "";
                    Log.Information("Deletes Skillset details");
                    return "Profile";
                case "15":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "skill_3", "Skills", userId);
                    }
                    trainer.Skill3 = "";
                    Log.Information("Deletes Skillset details");
                    return "Profile";
                case "16":
                    Console.WriteLine("Are you sure?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();

                    if (val == "1")
                    {
                        repo.UpdateATrainer("", "skill_4", "Skills", userId);
                    }
                    trainer.Skill4 = "";
                    Log.Information("Deletes Skillset details");
                    return "Profile";
                case "17":
                    Console.WriteLine("DO YOU WANT TO DELETE YOUR ACCOUNT!!");
                    Console.WriteLine("ARE YOU SURE?");
                    Console.WriteLine("[1] Proceed");
                    Console.WriteLine("[0] Abort");
                    val = Console.ReadLine();
                    if (val == "1")
                    {
                        repo.DeleteAccount(userId);
                        Log.Information("Deletes the account");
                        return "Trainer";
                    }
                   
                    else
                    {
                        return "Profile";
                    }


                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Profile";
            }
        }
    }
}