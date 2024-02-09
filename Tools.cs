namespace CommandLineReport;



public class MenuItem
{
    public string Label { get; set; }
    public Action? Action { get; set; }

  
}
public static class Tools
{
    public static void printMenu(List<MenuItem> menu,bool hasBack=false)
    {
        if (hasBack is true)
        {
            menu.Add(new MenuItem { Label = "Back", Action = () => { return; } });

        }
        int counter = 0;
        foreach (var menuItem in menu)
        {
            counter++;
            Console.WriteLine($"{counter}. {menuItem.Label}");
        }

        var selectedRow = Console.ReadLine();
        while (selectedRow is null||selectedRow.Length==0)
        {
            selectedRow = Console.ReadLine();
        }
        var index = int.Parse(selectedRow)-1;
        while (index > menu.Count-1 || index < 0)
        {
            Console.WriteLine($" {index} is wrong! enter another item");
            index = Int32.Parse(Console.ReadLine());
        }

        if (menu[index]?.Action is not null)
        {
            menu[index]?.Action();
        }
     
        // return ans;
    }

}
