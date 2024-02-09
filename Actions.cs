using System.Reflection;
using System.Reflection.Emit;
using ReportManager;

namespace CommandLineReport;

public static class Actions
{
    static IEnumerable<Type> FindReportImplementingTypes(Assembly assembly)
    {
        var reportType = typeof(IReport);

        return assembly.GetTypes().Where(type => reportType.IsAssignableFrom(type) && type.IsClass);
    }

    public static void ReadDll()
    {
        string? folderPath = null;
        while (folderPath is null)
        {
            Console.WriteLine("Enter Folder Path Name");
            folderPath = Console.ReadLine();
        }

        while (Directory.Exists(folderPath) is false)
        {
            Console.WriteLine("you're wrong , enter correct path");
            folderPath = Console.ReadLine();
        }

        string[] dllFiles = Directory.GetFiles(folderPath, "*.dll");
        List<IReport> instances = new List<IReport>();
        List<MenuItem> menuItems = new List<MenuItem>();

        foreach (var dllFile in dllFiles)
        {
            Assembly assembly = Assembly.LoadFrom(dllFile);


            Type[] types = (dynamic)assembly.GetTypes();


            foreach (Type type in types)
            {
                Console.WriteLine($" type is {type}");
                Type matchedItem = null;

                if (typeof(IReport).IsAssignableFrom(type))
                {
                    var instance = (dynamic)(Activator.CreateInstance(type) as IReport);
                    instances.Add((dynamic)instance);
                    menuItems.Add(new MenuItem { Label = instance?.Label });
                }
            }

        }
        Tools.printMenu(menuItems,true);

    }
}
