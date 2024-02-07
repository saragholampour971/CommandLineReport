using System.Reflection;

namespace DefaultNamespace;

public static class Actions
{

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

        List<Object> x = new List<Object>();
        {

        }


    }
}
