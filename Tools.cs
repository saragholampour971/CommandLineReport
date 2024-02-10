namespace CommandLineReport;

public static class Tools
{
    public static void printMenu( List<MenuItem> menu, string? Title=null, bool hasBack = false)
    {
        bool shouldExit = false;
        while (!shouldExit)
        {
            if (Title is not null)
                Tools.Print(Title, null, ConsoleColor.Green);

            List<MenuItem> copyMenu = new List<MenuItem>(menu);
            if (hasBack is true) copyMenu.Add(new MenuItem {Label = "Back"});

            var counter = 0;
            foreach (var menuItem in copyMenu)
            {
                counter++;
                Console.WriteLine($"{counter}. {menuItem.Label}");
            }

            try
            {
                Tools.Print("\n \n Please Enter an Option :",null,ConsoleColor.DarkYellow);
                var selectedRow = Console.ReadLine();
                var maximum = copyMenu.Count;

                int index;

                while (!int.TryParse(selectedRow, out index))

                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($" {index} is wrong! enter another item");
                    Console.ResetColor();
                    selectedRow = Console.ReadLine();
                    index = int.Parse(selectedRow);
                }

                index = int.Parse(selectedRow) - 1;
                if (copyMenu[index]?.Action is not null) copyMenu[index]?.Action();
                else shouldExit = true;

                if (!hasBack)
                    shouldExit = true;

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"oops {e.Message}");
            }
        }
    }


    public static void Print(string text, System.ConsoleColor? BackgroundColor = null,
        System.ConsoleColor? ForegroundColor = null)
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
