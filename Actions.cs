using System.Reflection;
using CommandLineReport;
using Report;

namespace DefaultNamespace;

public static class Actions
{
    static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
                return true;
            toCheck = toCheck.BaseType;
        }

        return false;
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
        Console.WriteLine($" count of dll is {dllFiles.Length}");
        foreach (string dllFile in dllFiles)
        {
            Assembly assembly = Assembly.LoadFrom(dllFile);

            // =====================================
            Type[] types = assembly.GetTypes();
            List<Report<object>> instances = new List<Report<object>>();
            // Iterate over each type in the assembly
            foreach (Type type in types)
            {
                Type matchedItem = null;


                if (IsSubclassOfRawGeneric(typeof(Report<>), type))
                {
                    Console.WriteLine($"generic class named {type.FullName}");
                    matchedItem = type;
                }


                if (matchedItem is not null)
                {
                    var instance = Activator.CreateInstance(matchedItem) as Report<object>;
                    instances.Add(instance);
                    Console.WriteLine($">>'{type.FullName}'{matchedItem.FullName} loaded successfully ");
                }
            }
        }
    }
}
