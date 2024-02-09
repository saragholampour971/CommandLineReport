namespace CommandLineReport;

public enum Status
{
    Enable,
    Disable
}

public record History
{
    public DateTime FulfilledDate { get; set; }
    public string TaskLabel { get; set; }
    public Status Status { get; set; }
}

public static class MyReportManager
{
    public static string FolderPath { get; set; }
    public static List<History> Histories { get; set; }
    public static List<Extention> Extentions { get; set; }

    public static void PrintSubMenus(Extention extention)
    {
        Tools.Print("Select Report :",null,ConsoleColor.Yellow);
        var items = extention.SubMenus.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
            {
                Tools.Print($"Result of '{i.Label} ' of {extention.Label} Category  : {i.Result()}",null,ConsoleColor.DarkYellow);
            }
        })?.ToList();
        if (items is not null) Tools.printMenu(items, true);
    }


    public static void PrintExtentions(List<Extention> extentions)
    {
        Tools.Print("Select category: ",null,ConsoleColor.Green);
        Tools.printMenu(Extentions.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
                PrintSubMenus(i)
        }).ToList(), true);
    }


    public static void PrintManiMenu()
    {
        while (true)
        {
            var firstMenu = new List<MenuItem>
            {
                new()
                {
                    Label = "Read Extentions", Action = () =>
                    {
                        Actions.ReadDll();
                        if (Extentions?.Count > 0) PrintExtentions(Extentions);
                    }
                },
                new() { Label = "Manage Extentions", Action = null }
            };

            Tools.Print("* * * * * * * * * * * * * * *",null,ConsoleColor.Cyan);
            Tools.Print("*    Welcome to your app    *",null,ConsoleColor.Cyan);
            Tools.Print("* * * * * * * * * * * * * * *",null,ConsoleColor.Cyan);

            Tools.printMenu(firstMenu);
        }
    }
}
