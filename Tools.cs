using System.Reflection;
using CommandLineReport.enums;
using ReportManager;

namespace CommandLineReport;

public static class Tools
{

    // read dll from folder and put theme to param list
    public static void ReadDll(out List<Extention> extentions)
    {
        while (MyReportManager.FolderPath is null)
        {
            Tools.Print("Enter Folder Path Name",ConsoleColor.Blue,null);

            MyReportManager.FolderPath = Console.ReadLine();
        }

        while (Directory.Exists(MyReportManager.FolderPath) is false)
        {
            Tools.Print("you're wrong , enter correct path",null,ConsoleColor.Red);
            MyReportManager.FolderPath = Console.ReadLine();
        }

        var dllFiles = Directory.GetFiles(MyReportManager.FolderPath, "*.dll");
        var instances = new List<Extention>();
        var menuItems = new List<MenuItem>();

        foreach (var dllFile in dllFiles)
        {
            var assembly = Assembly.LoadFrom(dllFile);


            var types = assembly.GetTypes();


            foreach (var type in types)
            {
                Type matchedItem = null;

                if (typeof(IReport).IsAssignableFrom(type))
                {
                    var instance = (dynamic)(IReport)Activator.CreateInstance(type);
                    instances.Add((dynamic)new Extention
                        { Status = Status.Enable, SubMenus = instance.SubMenus, Label = instance.Label });

                    menuItems.Add((dynamic)new MenuItem { Label = instance?.Label });
                }
            }
        }

        extentions = instances;
    }




    // just need to pass list of label of each menu item & action , each menu item selected , action of it will be fire.
    // this func has some feature .
    // Title is title of menu .
    // has back is added back item to menu
    // also this func check input ,to user only print number & check to be less than menu count
    public static void PrintMenu( List<MenuItem> menu, string? Title=null, bool hasBack = false)
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
                Tools.Print("\n \n Please Enter an Option :", null, ConsoleColor.DarkYellow);
                var selectedRow = Console.ReadLine();
                var maximum = copyMenu.Count;

                int index;

                while (!int.TryParse(selectedRow, out index))

                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($" wrong! enter another item");
                    Console.ResetColor();
                    selectedRow = Console.ReadLine();

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
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"oops {e.Message}");
            }
        }
    }

// for print string with custom color
    public static void Print(string text, System.ConsoleColor? BackgroundColor = null, System.ConsoleColor? ForegroundColor = null)
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
