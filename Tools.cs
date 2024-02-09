namespace CommandLineReport;

public class MenuItem
{
    public string Label { get; set; }
    public Action? Action { get; set; }
}

public static class Tools
{
    public static void printMenu(List<MenuItem> menu, bool hasBack = false)
    {
        if (hasBack is true)
        {
            menu.Add(new MenuItem { Label = "Back", Action = () => { return; } });
        }

        int counter = 0;
        foreach (var menuItem in menu)
        {
            counter++;
            Console.WriteLine($"{counter}. {menuItem.Label}");
        }

        var selectedRow = Console.ReadLine();
        int maximum = menu.Count - 1;
        while (selectedRow is null || selectedRow.Length == 0)
        {
            selectedRow = Console.ReadLine();
        }

        var index = int.Parse(selectedRow) ;
        while (index-1 > maximum || index-1 < 0)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {index} is wrong! enter another item");
            Console.ResetColor();
            index = int.Parse(Console.ReadLine());
        }

        if (menu[index-1]?.Action is not null)
        {
            menu[index-1]?.Action();
        }

        // return ans;
    }


    public static int ReadConsole(int? maximum = int.MaxValue)
    {
        string input;
        int numericAns;

        while (true)
        {
            input = Console.ReadLine();
            ;
            if (int.TryParse(input, out numericAns) && numericAns <= maximum && numericAns >= 0)
            {
                numericAns -= 1;
                break;
            }
            else
            {
                Console.WriteLine("invalid input. Try something new:");
            }
        }

        return numericAns;
    }


    public static void ShowSubMenus(Extention extention)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Select Report :");
        Console.ResetColor();
        List<MenuItem>? items = extention.SubMenus.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;   
                Console.WriteLine($"Result of '{i.Label} ' of {extention.Label} Category  : {i.Result()}");
                Console.ResetColor();
            }
        })?.ToList();
        if (items is not null)
        {
            Tools.printMenu(items, true);
        }
    }


    public static void PrintExtentions(List<Extention> extentions)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Select category: ");
        Console.ResetColor();
        Tools.printMenu(MyReportManager.Extentions.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
                Tools.ShowSubMenus(i)
        }).ToList(), true);
    }
}
