namespace CommandLineReport;

public enum Status
{
    Enable,
    Disable
}

public class History
{
    public DateTime FulfilledDate { get; set; }
    public string TaskLabel { get; set; }
}

public static class MyReportManager
{
    public static string FolderPath { get; set; }
    public static List<History> Histories { get; set; } = new List<History>();

    public static List<Extention> Extensions { get; set; } = new List<Extention>() { };

// ----------------------------------------------------------------------------


    public static void PrintMainMenu()
    {
        while (true)
        {
            var firstMenu = new List<MenuItem>
            {
                new MenuItem
                {
                    Label = "Read Extentions", Action = () =>
                    {
                        Actions.ReadDll();
                        if (Extensions?.Count > 0) PrintExtensions(Extensions);
                    }
                },
                new MenuItem
                {
                    Label = "Manage Extentions", Action = () => ManageExtensions()
                },
                new MenuItem {Label = "View report History", Action = PrintHistories}
            };

            Tools.Print("* * * * * * * * * * * * * * *", null, ConsoleColor.Cyan);
            Tools.Print("*    Welcome to your app    *", null, ConsoleColor.Cyan);
            Tools.Print("* * * * * * * * * * * * * * *", null, ConsoleColor.Cyan);

            Tools.printMenu(firstMenu, "What do you want ?");
        }
    }

    public static void SaveHistory(string TaskName)
    {
        Histories.Add(new History{TaskLabel = TaskName,FulfilledDate = DateTime.Now});
    }

    public static void PrintSubMenus(Extention extention)
    {
        var items = extention.SubMenus.Select(i => new MenuItem
        {
            Label = i.Label,
            Action = () =>
            {
                MyReportManager.SaveHistory($" '{extention.Label} >> {i.Label}'  ");
                Tools.Print($"Result of '{i.Label} ' of {extention.Label} Category  : {i.Result()} \n", null,
                    ConsoleColor.DarkCyan);
            }
        })?.ToList();
        if (items is not null)
        {
            Console.Clear();
            Tools.printMenu(items, "select report : ", true);
        }
    }


    public static void PrintExtensions(List<Extention> extentions)
    {
        List<MenuItem> list = new List<MenuItem>();
        list = Extensions.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
                PrintSubMenus(i)
        }).ToList();

        Console.Clear();
        Tools.printMenu(list, "select Category", true);
    }

    public static void ManageExtensions()
    {
        if (Extensions.Count == 0)
        {
            Tools.Print("there is no extension . ", null, ConsoleColor.Red);
        }
        else
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                List<MenuItem> list = new();

                foreach (Extention extension in Extensions)
                {
                    list.Add(new MenuItem
                    {
                        Label = $"{extension.Status}       | {extension.Label}", Action =
                            () =>
                            {
                                MyReportManager.SaveHistory($" change status of '{extension.Label}'  ");

                                extension.Status = extension.Status == Status.Enable ? Status.Disable : Status.Enable;
                            }
                    });
                }

                list.Add(new MenuItem {Label = "Back", Action = () => { shouldExit = true; }});

                Console.Clear();
                Tools.printMenu( list, " Manage Extentions \n    State       | Extension Name    ");
            }
        }
    }





    public static void PrintHistories()
    {
        if ( Histories.Count==0)
        {
            Tools.Print("there is no history ", null,ConsoleColor.Red);
        }
        else
        {
            foreach (var history in Histories)
            {
                Tools.Print($"Run {history.TaskLabel}  on {history.FulfilledDate}");
            }
        }
    }
}
