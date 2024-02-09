using System.Reflection;
using ReportManager;

namespace CommandLineReport;

public static class Actions
{
    public static void ReadDll()
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

        MyReportManager.Extentions = instances;
    }
}
