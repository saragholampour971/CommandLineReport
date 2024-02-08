namespace CommandLineReport;



public class MenuItem
{
    public string Label { get; set; }
    public Action? Action { get; set; }

  
}
public static class Tools
{
    public static void printMenu(List<MenuItem> menu)
    {
        int counter = 0;
        foreach (var menuItem in menu)
        {
            counter++;
            Console.WriteLine($"{counter}. {menuItem.Label}");
        }

        var index = Int32.Parse(Console.ReadLine())-1;
        while (index > menu.Count-1 || index < 0)
        {
            Console.WriteLine($" {index} is wrong! enter another item");
            index = Int32.Parse(Console.ReadLine());
        }

        if (menu[index]?.Action is not null)
        {
            Console.WriteLine("action is not null");
            menu[index]?.Action();
        }
        else Console.WriteLine("action is null");
     
        // return ans;
    }

}
