using FindTrainers;

namespace FindTrainers
{
    internal class Initial:TSignUp
    {
        static void Main(string[] args)
        {
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