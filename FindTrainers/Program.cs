using FT_UIConsole;

bool repeat = true;
IMenu menu= new Menu();

while (repeat)
{
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "Trainer":
            menu =new Trainer();
            break;
        case "TSignUp":
            menu= new TSignUp();
            break;
        case "Exit":
            repeat= false;
            break;
        case "Menu":
            menu = new Menu();
            break;

        default:
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}
