using System.Reflection;
using System.Reflection.Emit;
using ReportManager;

namespace CommandLineReport;

public static class Actions
{

    public static void ReadDll()
    {
        while (MyReportManager.FolderPath is null)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter Folder Path Name");
            Console.ResetColor();

            MyReportManager.FolderPath = Console.ReadLine();
        }

        while (Directory.Exists(MyReportManager.FolderPath) is false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("you're wrong , enter correct path");
            Console.ResetColor();
            MyReportManager.FolderPath = Console.ReadLine();
        }

        string[] dllFiles = Directory.GetFiles(MyReportManager.FolderPath, "*.dll");
        List<Extention> instances = new List<Extention>();
        List<MenuItem> menuItems = new List<MenuItem>();

        foreach (var dllFile in dllFiles)
        {
            Assembly assembly = Assembly.LoadFrom(dllFile);


            Type[] types = (dynamic)assembly.GetTypes();


            foreach (Type type in types)
            {
                Type matchedItem = null;

                if (typeof(IReport).IsAssignableFrom(type))
                {
                    var instance = (dynamic)(IReport)(Activator.CreateInstance(type));
                    instances.Add((dynamic)new Extention(){Status = Status.Enable,SubMenus=instance.SubMenus ,Label = instance.Label});
                    
                    menuItems.Add((dynamic)new MenuItem { Label = instance?.Label });
                }
            }

        }

        MyReportManager.Extentions = instances;
    }
}
