﻿global using Serilog;
using FindTrainers;


namespace FindTrainers
{
    internal class Initial:TSignUp
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"..\..\..\logs.txt", rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true).CreateLogger();

            Log.Logger.Information("PROGRAM STARTS");

            bool repeat = true;
            IMenu menu = new Menu();

            while (repeat)
            {
                menu.Display();
                string ans = menu.UserChoice();

                switch (ans)
                {
                    case "Trainer":
                        menu = new Trainer();
                        break;
                    case "TSignUp":
                        menu = new TSignUp();
                        break;
                    case "Exit":
                        repeat = false;
                        break;
                    case "Menu":
                        trainer=new Datafile.TrainerDetails();
                        menu = new Menu();
                        break;
                    case "Profile":
                        menu = new Profile(trainer);
                        break;
                    case "TLogIn":
                        menu = new TLogIn();
                        break;
                    case "TUpdate":
                        menu = new TUpdate();
                        break;
                    case "TDelete":
                        menu = new TDelete();
                        break;
                    case "User":
                        menu = new Users();
                        break;


                    default:
                        Console.WriteLine("Page does not exist!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}