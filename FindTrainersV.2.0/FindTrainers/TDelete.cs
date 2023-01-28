using ConsoleTables;
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

            Console.WriteLine("[12] Company Details and Experience in years");



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



            Console.WriteLine("[17] DELETE YOUR ACCOUNT !!!!!");
        }

        public new string UserChoice()
        {
            String[] arr = tr.Email.Split("@");
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
                    tr.PhoneNo = "";
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
                    tr.City = "";
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
                    cug.CollegeName = "";
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
                    cug.YearPassed="";
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
                    cug.Degree = "";
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
                    cug.Branch = "";
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

                    hsc.SchoolName= "";
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

                    hsc.YearPassed = "";
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
                    hs.SchoolName = "";
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
                    hs.YearPassed = "";
                    Log.Information("Deletes HSP year");
                    return "Profile";
                case "12":
                    Console.WriteLine("Enter the company name to delete the record");
                    string cname=Console.ReadLine();

                 
                    var comp=companies.SingleOrDefault(x=>x.TrainerId==userId && x.LastCompanyName==cname);
                    if (comp!=null)
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
                            companies.Remove(comp);

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
                    sk.Skill1 = "";
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
                    sk.Skill2 = "";
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
                   sk.Skill3 = "";
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
                    sk.Skill4 = "";
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