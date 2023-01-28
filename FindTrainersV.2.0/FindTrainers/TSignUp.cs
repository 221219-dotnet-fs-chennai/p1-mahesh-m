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


namespace FindTrainers
{
    internal class TSignUp : IMenu
    {
        

        internal static Models.Trainer tr =new Models.Trainer();
        internal static Models.Skill sk=new Models.Skill();
        internal static Models.HighSchool hs= new Models.HighSchool();
        internal static Models.HighSec hsc =new Models.HighSec();
        internal static Models.CollegeUg cug= new Models.CollegeUg();
        internal static Models.Company com = new Models.    Company();  
       internal static List<Models.Company> companies=new List<Models.Company>();


        string? nameRegex = @"\w{3,50}";
        string? emailRegex = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-z]{2,6}$";
        string? phoneRegex = @"^[9876]\d{9}$";
        string? yearRegex= @"^\d{4}$";
        string? degreeRegex = @"^B\.\w{1,6}$";
        string? passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
     
        public TSignUp() {
            
        
        }

        public TSignUp(Models.Trainer tra,Models.HighSchool hsl,Models.HighSec hscl,List<Models.Company>cmp,Models.Skill sks,Models.CollegeUg col)
        {
            tr = tra;
            hs = hsl;
            hsc= hscl;
            companies=cmp;
            sk=sks;
            cug=col;
        }


        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");

        BusinessLogic.IRepo repo = new BusinessLogic.EFRepo();


        //IRepo repo = new SqlRepo(s[0], s[1]);
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


            Console.WriteLine("[2] First Name" + "                           - "+ tr.FirstName);
            Console.WriteLine("[3] Last Name" + "                            - " + tr.LastName);
            Console.WriteLine("[4] Email ID" + "                             - " + tr.Email);
            Console.WriteLine("[5] Phone No." + "                            - " + tr.PhoneNo);
            Console.WriteLine("[6] City"+"                                   - "+ tr.City) ;
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
                var table =new ConsoleTable("Companies", "Experience in Years");
                foreach (var e in companies)
                {

                    //Console.WriteLine("                                             ---------------------------");
                    //Console.WriteLine("                                             |  " + e.Key + "        |      " + e.Value + "  |  ");
                    //Console.WriteLine("                                             ---------------------------");

                    table.AddRow(e.LastCompanyName,e.TotalExp);





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

            Console.WriteLine("[21] Password" );

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
                    //var cont = new TrainerDetailsContext();
                    //var tra = new EntityFramework.newEntities.Trainer()
                    //{
                    //    Email = trainer.Email,
                    //    FirstName = trainer.FName, LastName = trainer.FName,
                    //    City = trainer.City,
                    //    PhoneNo = trainer.PhoneNo,
                    //    Password = trainer.Password,
                    //    TrainerId = trainer.Email.Split('@')[0]
                    //};
                    //cont.Trainers.Add(tra);
                    repo.InsertTrainers(tr, sk, hsc, hs, companies, cug);
                    

            return "Trainer";




                    //try
                    //{
                    //    repo.Insert(trainer);
                    //}
                    //catch (NullReferenceException ex) {
                    //    Console.Clear();
                    //    Console.WriteLine("********************************************************PLEASE FILL ALL THE DETAILS***********************************************************");
                    //    Console.WriteLine();
                    //    Console.WriteLine("**************************************************************BEFORE SAVING********************************************************************");
                    //    Console.ReadLine();
                    //    Log.Logger.Information("trainer didn't enter all details");
                    //    //Log.Logger.Fatal("Trainer didn't enter all the details");
                    //    return "TSignUp";
                    //}
                    //Log.Information("Trainer registeration Complete");
                    return "Profile";

                case "2":
                    Console.WriteLine("Enter First Name");
                    string str = Console.ReadLine();
                    while (!FormatChecker(str,nameRegex))
                    {
                       Console.WriteLine("First Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.FName = str;
                    tr.FirstName = str;

                    return "TSignUp";
                case "3":
                    Console.WriteLine("Enter Last Name");
                     str = Console.ReadLine();
                    while (!FormatChecker(str,nameRegex))
                    {
                        Console.WriteLine("Last Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.LName = str;
                    tr.LastName = str;
                    return "TSignUp";
                case "4":
                    Console.WriteLine("Enter Email ID");
                    str= Console.ReadLine();
                    while (!FormatChecker(str,emailRegex))
                    {
                        Console.WriteLine("Email format is invalid! Re-enter email");
                        str = Console.ReadLine();
                    }
                    //if(repo.IsExist(str,"email")) {
                    //    Console.WriteLine("Email is Associated with another account. Try signing up with different account!");
                    //    Console.ReadLine() ;



                    //    return "TSignUp";

                    //}
                    //else
                    //{

                    //    //trainer.Email = str;


                    //}
                    tr.Email = str;
                    tr.TrainerId = str.Split("@")[0];
                    hs.TrainerId = tr.TrainerId;
                    hsc.TrainerId = tr.TrainerId;
                    cug.TrainerId= tr.TrainerId;
                    sk.TrainerId=tr.TrainerId;
                    return "TSignUp";



                case "5":
                    Console.WriteLine("Enter Phone No.");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, phoneRegex))
                    {
                        Console.WriteLine("Phone No. format is invalid! Re-enter Phone No.");
                        str = Console.ReadLine();
                    }
                    //if (repo.IsExist(str, "phoneNo"))
                    //{
                    //    Console.WriteLine("Phone No. is Associated with another account. Try add different phone number!");
                    //    Console.ReadLine();



                    //    return "TSignUp";

                    tr.PhoneNo = str;
                    return "TSignUp";
                //else
                //{

                //    //trainer.PhoneNo = str;


                //}



                case "6":
                    Console.WriteLine("Enter City name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("City should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.City = str;
                    tr.City= str;
                    return "TSignUp";

                case "7":
                    Console.WriteLine("Enter Bachelor's College Name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("College Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.UGCName= str;
                    cug.CollegeName = str;
                    return "TSignUp";
                case "8":
                    Console.WriteLine("Enter Bachelor's Year of Passing");
                     str = Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str)>2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    //trainer.UGPYear = str;
                    cug.YearPassed= str;
                    return "TSignUp";
                case "9":
                    Console.WriteLine("Enter Bachelor's Degree (Format eg: B.Tech,B.A,B.Sc");
                    str = Console.ReadLine();
                    while (!FormatChecker(str,degreeRegex ))
                    {
                        Console.WriteLine("Please use the correct format for degree");
                        str = Console.ReadLine();
                    }
                    //trainer.UGDegree= str;
                    cug.Degree=str;

                    return "TSignUp";
                case "10":
                    Console.WriteLine("Enter Bachelor's Specialization");
                    str= Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Specializtion should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.UGDept = str;
                    cug.Branch=str;
                    return "TSignUp";
                case "11":
                    Console.WriteLine("Enter HigherSec School Name");
                    str= Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Higher Secondary School Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.HSCName= str;
                    hsc.SchoolName=str;
                    return "TSignUp";
                case "12":
                    Console.WriteLine("Enter HigherSec School Year of Passing");
                    str= Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    //trainer.HSCPYear= str;
                    hsc.YearPassed=str;
                    return "TSignUp";
                case "13":
                    Console.WriteLine("Enter HigherSec School Stream");
            
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Higher Secondary Stream should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.HSCStream = str;
                    hsc.Course=str;

                    return "TSignUp";
                case "14":
                    Console.WriteLine("Enter High School Name");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("High School Name should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.HSName= str;
                    hs.SchoolName= str;
                    return "TSignUp";
                case "15":
                    Console.WriteLine("Enter High School Year of Passing");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, yearRegex) || int.Parse(str) > 2023)
                    {
                        Console.WriteLine("Re-enter the correct year!");
                        str = Console.ReadLine();
                    }
                    //trainer.HSPYear= str;   
                    hs.YearPassed=str;
                    return "TSignUp";
                case "16":
                    Console.WriteLine("Enter Company Name");
                    string compny= Console.ReadLine();

                    while (!FormatChecker(compny, nameRegex))
                    {
                        Console.WriteLine("Company name should be 3 to 50 characters long");
                         compny= Console.ReadLine();
                    }

                    Console.WriteLine("Enter your experience in years");
                    string ? experience= Console.ReadLine();
                    int e = Convert.ToInt32(experience);
                    while (e < 1 || e > 30)
                    {
                        Console.WriteLine("Give correct experience information");
                        experience = Console.ReadLine();
                        e = Convert.ToInt32(experience);
                    }

                    //trainer.SetCompany(compny, experience);
                    companies.Add(new Company()
                    {
                        TrainerId = tr.Email.Split("@")[0],
                       LastCompanyName=compny,
                       TotalExp=e
                    });



                    Console.WriteLine("Do you have any other experience? Type (Y/N)");
              
                    string c = Console.ReadLine();
                    while(c=="Y" || c == "y")
                    {
                        Console.WriteLine("Enter Company Name");
                       compny = Console.ReadLine();

                        while (!FormatChecker(compny, nameRegex))
                        {
                            Console.WriteLine("Company name should be 3 to 50 characters long");
                            compny = Console.ReadLine();
                        }

                        Console.WriteLine("Enter your experience");
                         experience = Console.ReadLine();
                         e = Convert.ToInt32(experience);
                        while (e<1 || e > 30)
                        {
                            Console.WriteLine("Give correct experience information");
                            experience= Console.ReadLine();
                            e = Convert.ToInt32(experience);
                        }

                        //trainer.SetCompany(compny, experience);
                        companies.Add(new Company()
                        {
                            TrainerId = tr.Email.Split("@")[0],
                            LastCompanyName = compny,
                            TotalExp = e
                        });


                        Console.WriteLine("Do you have any other experience? Type (Y/N)");
                        c= Console.ReadLine();
         

                    }


                    return "TSignUp";
         
                case "17":
                    Console.WriteLine("Enter your Primary Skill");
                    str= Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Primary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.Skill1 = str;
                    sk.Skill1= str;
                    return "TSignUp";
                case "18":
                    Console.WriteLine("Enter your Secondary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Secondary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.Skill2= str;
                    sk.Skill2=str;
                    return "TSignUp";
                case "19":
                    Console.WriteLine("Enter your Tertiary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Tertiary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.Skill3 = str;
                    sk.Skill3= str;
                    return "TSignUp";
                case "20":
                    Console.WriteLine("Enter your Quaternary Skill");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, nameRegex))
                    {
                        Console.WriteLine("Quarternary Skill should be 3 to 50 characters long");
                        str = Console.ReadLine();
                    }
                    //trainer.Skill4 = str;
                    sk.Skill4= str;
                    return "TSignUp";
                case "21":
                    Console.WriteLine("Enter your Password");
                    str = Console.ReadLine();
                    while (!FormatChecker(str, passwordRegex))
                    {
                        Console.WriteLine("Password min 8 characters, atleast 1 lower case,1 upper case,1 number");
                        str = Console.ReadLine();
                    }
                    Console.WriteLine("Retype password to Confirm Password");
                    string cPass = Console.ReadLine();
                    while (!str.Equals(cPass))
                    {
                        Console.WriteLine("Passwords are not matching! Re type confirm password! ");
                        cPass = Console.ReadLine();
                    }
                    //trainer.Password = str;
                    tr.Password = str;
                    return "TSignUp";

                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TSignUp";

            }
        }
        
        public bool FormatChecker(string str,string regex)
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
