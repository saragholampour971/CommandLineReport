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
            var maximum = menu.Count - 1;
            while (selectedRow is null || selectedRow.Length == 0) selectedRow = Console.ReadLine();

            int index;
            int.TryParse(selectedRow, out index);
            while ((index != 0 && index - 1 > maximum) || index - 1 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($" {index} is wrong! enter another item");
                Console.ResetColor();
                index = int.Parse(Console.ReadLine());
            }

            if (menu[index - 1]?.Action is not null) menu[index - 1]?.Action();
        }
        catch (Exception e)
        {
            Console.WriteLine($"oops {e.Message}");
        }

    }


    public static void Print(string text, System.ConsoleColor? BackgroundColor, System.ConsoleColor? ForegroundColor)
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
