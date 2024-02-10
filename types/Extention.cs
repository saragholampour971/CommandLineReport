using ReportManager;

namespace CommandLineReport;

public class Extention : IReport
{
    public Status Status { get; set; }
    public string Label { get; set; }

    public List<ISubMenu> SubMenus { get; set; }
}
