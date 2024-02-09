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
    public static List<Extention> Extensions { get; set; } = new List<Extention>(){};

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


    public static void PrintExtensions(List<Extention> extentions)
    {
        Tools.Print("Select category: ",null,ConsoleColor.Green);
        Tools.printMenu(Extensions.Select(i => new MenuItem
        {
            Label = i.Label, Action = () =>
                PrintSubMenus(i)
        }).ToList(), true);
    }



    public static void ManageExtensions()
    {
        if (MyReportManager.Extensions.Count==0)
        {
            Tools.Print("there is no extension . ",null,ConsoleColor.Red);
        }
        else
        {
            Tools.Print("Manage Extensions",null,ConsoleColor.Yellow);
            Tools.Print("State              | Extension Name            ",ConsoleColor.DarkBlue);

            foreach (Extention extension in MyReportManager.Extensions)
            { 
                Tools.Print($"{extension.Status}       | {extension.Label}");
            }
        }
  
    }


    public static void PrintManiMenu()
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
                new MenuItem { Label = "Manage Extentions", Action = () =>
                {
                    Console.WriteLine("asdfasdfasdfasdf");
                    ManageExtensions();
                } }
                ,new MenuItem{Label = "View report History",Action = null}
            };

            Tools.Print("* * * * * * * * * * * * * * *",null,ConsoleColor.Cyan);
            Tools.Print("*    Welcome to your app    *",null,ConsoleColor.Cyan);
            Tools.Print("* * * * * * * * * * * * * * *",null,ConsoleColor.Cyan);

            Tools.printMenu(firstMenu);
        }
    }
}
