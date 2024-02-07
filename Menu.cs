using DefaultNamespace;

namespace CommandLineReport;

public class Menu
{


    public void RunMenu()
    {


        while (true)
        {
            Console.WriteLine("1. Run Report");
            Console.WriteLine("2. Show Record Count");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                   Actions.ReadDll();
                    break;
                // case "2":
                //     ShowRecordCount();
                //     break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
