using Datafile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindTrainers
{
    internal class TLogIn : IMenu
    {
        string? emailRegex = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-z]{2,6}$";
        string? phoneRegex = @"^[9876]\d{9}$";
        string? passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
        static string[] s = File.ReadAllLines(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Datafile\Connection.txt");

        IRepo repo = new SqlRepo(s[0], s[1]);
        public void Display()
        {
            Console.WriteLine($"<-------------------------- LOGIN PAGE ----------------------------->");
            Console.WriteLine();
            Console.WriteLine("[0] Go Back :)");
            Console.WriteLine("[1] Continue with log In");
            Console.WriteLine("[2] Forgot Password");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":

                    return "Trainer";
                case "1":
                    Log.Information("Trainer Tries Loggin in");
                    Console.WriteLine("Enter email id");
                    string? email = Console.ReadLine();
                    bool res= repo.Login(email);
                    if (res)
                    {
                        TSignUp newTrainer = new TSignUp(repo.GetATrainer(email));
                        Log.Information("Trainer has logged in Successfully");
                        return "Profile";
                    }
                    else {
                        Log.Information("Trainer Couldn't log in");
                        return "TLogIn";
                    }
                case"2":
                    Console.WriteLine("Enter the email");
                    string str= Console.ReadLine();
                    while (!FormatChecker(str, emailRegex))
                    {
                        Console.WriteLine("Email format is invalid! Re-enter email");
                        str = Console.ReadLine();
                    }
                    if (repo.IsExist(str, "email"))
                    {
                        Console.WriteLine("Enter the phone number");
                        string str1=Console.ReadLine();
                        while (!FormatChecker(str1, phoneRegex))
                        {
                            Console.WriteLine("Phone No. format is invalid! Re-enter Phone No.");
                            str1 = Console.ReadLine();
                        }
                        if (repo.IsExist(str1, "phoneNo"))
                        {
                            Console.WriteLine("Enter the new password");
                            string newPass=Console.ReadLine();

                            while (!FormatChecker(newPass, passwordRegex))
                            {
                                Console.WriteLine("Password min 8 characters, atleast 1 lower case,1 upper case,1 number");
                                newPass = Console.ReadLine();
                            }
                            Console.WriteLine("Retype password to Confirm Password");
                            string cPass = Console.ReadLine();
                            while (!newPass.Equals(cPass))
                            {
                                Console.WriteLine("Passwords are not matching! Re type confirm password! ");
                                
                                cPass = Console.ReadLine();
                            }
                            repo.NewPass(newPass, str);
                           
                            Console.ReadLine();



                            return "TLogIn";

                        }
                        else
                        {
                            Console.WriteLine("Phone no is not matching with email");
                            Console.ReadLine();

                            return "TLogIn";


                        }
                      
                    }
                    else
                    {

                        Console.WriteLine("Can't Find your account! Retry again!!");
                        Console.ReadLine();
                        return "TLogIn";

                    }

                    
                    
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "TLogIn";




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
