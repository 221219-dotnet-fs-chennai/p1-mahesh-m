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
        case "":
            repeat= false;
            break;

        default:
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}
