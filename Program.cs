using CommandLineReport;

class Program
{
    static void Main(string[] args)
    {

        // Menu loop
        // Menu menu = new Menu();
        while (true)
        {
            List<MenuItem> firstMenu = new List<MenuItem>{
                new MenuItem{Label = "Read Extentions",Action = () =>
                {
                    Actions.ReadDll();
                    if (MyReportManager.Extentions?.Count>0)
                    {
                        Tools.PrintExtentions(MyReportManager.Extentions);
                       
                    }
                }},
                new MenuItem{Label = "Manage Extentions",Action = null}
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("* * * * * * * * * * * * * * *");
Console.WriteLine("*    Welcome to your app    *");
Console.WriteLine("* * * * * * * * * * * * * * *");
Console.ResetColor();

            Tools.printMenu(firstMenu);
            
        }
    }
}
