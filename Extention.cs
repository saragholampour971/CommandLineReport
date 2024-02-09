using ReportManager;

namespace CommandLineReport;

public class Extention:IReport
{
    public string Label { get; set; }

    public List<ISubMenu> SubMenus { get; set; }
    public Status Status { get; set; }
    public Extention(){}
}
