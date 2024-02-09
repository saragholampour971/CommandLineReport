namespace CommandLineReport;



public static class Tools
{
    public static void printMenu(List<MenuItem> menu, bool hasBack = false)
    {
        if (hasBack is true) menu.Add(new MenuItem { Label = "Back", Action = () => { } });

        var counter = 0;
        foreach (var menuItem in menu)
        {
            counter++;
            Console.WriteLine($"{counter}. {menuItem.Label}");
        }

        try
        {
            var selectedRow = Console.ReadLine();
            var maximum = menu.Count ;
            int index ;
        
            while (!int.TryParse(selectedRow, out index))

            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($" {index} is wrong! enter another item");
                Console.ResetColor();
                selectedRow = Console.ReadLine();
                 index = int.Parse(selectedRow);

            }
            index = int.Parse(selectedRow)-1;
            if (menu[index]?.Action is not null) menu[index]?.Action();
        }
        catch (Exception e)
        {
            Console.WriteLine($"oops {e.Message}");
        }

    }


    public static void Print(string text, System.ConsoleColor? BackgroundColor=null, System.ConsoleColor? ForegroundColor=null)
    {
        if (BackgroundColor.HasValue)
        {
            Console.BackgroundColor = BackgroundColor.Value;
        }
        else if (ForegroundColor.HasValue)
        {
            Console.ForegroundColor = ForegroundColor.Value;
        }
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
