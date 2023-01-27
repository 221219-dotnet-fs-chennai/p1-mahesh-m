global using Serilog;
using FindTrainers;


namespace FindTrainers
{
    internal class Initial:TSignUp
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Maheshabi\newRepo\p1-mahesh-m\FindTrainers\Logs\logs.txt", rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true).CreateLogger();

            Log.Logger.Information("**********************************************************************PROGRAM STARTS***********************************************************************");

            bool repeat = true;
            IMenu menu = new Menu();

            while (repeat)
            {
                Console.Clear();

                Log.Logger.Information("Showing the main menu to the trainer");
                menu.Display();
                string ans = menu.UserChoice();

                switch (ans)
                {
                    case "Trainer":
                        trainer = new Datafile.TrainerDetails();
                        menu = new Trainer();
                        break;
                    case "TSignUp":
                        Log.Logger.Information("Trying to get into Sign Up Page");
                        menu = new TSignUp();
                        break;
                    case "Exit":
                        Log.Logger.Information("*************************************************************************PROGRAM ENDS**********************************************************************");
                        repeat = false;
                        break;
                    case "Menu":
                        Log.Logger.Information("Entering Main menu / Logging out");
                        trainer=new Datafile.TrainerDetails();
                        menu = new Menu();
                        break;
                    case "Profile":
                        Log.Logger.Information("Logging into trainer profile page");
                        menu = new Profile(tr,hs,hsc,companies,sk,cug);
                        break;
                    case "TLogIn":
                        Log.Logger.Information("Displaying Trainer Login Page");
                        menu = new TLogIn();
                        break;
                    case "TUpdate":
                        Log.Logger.Information("Displaying Trainer update Page");
                        menu = new TUpdate();
                        break;
                    case "TDelete":
                        Log.Logger.Information("Displaying Trainer delete page");
                        menu = new TDelete();
                        break;
                    case "User":
                        Log.Logger.Information("Enter into the Learner");
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