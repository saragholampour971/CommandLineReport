using ReportManager;

namespace CommandLineReport;

public enum Status
{
    Enable,
    Disable
}

public record History
{
    public DateTime FulfilledDate { get; set; }
    public string TaskLabel { get; set; }
    public Status Status { get; set; }
}

public static class MyReportManager
{
    public static string FolderPath { get; set; }
    public static List<History> Histories { get; set; }
    public static List<Extention> Extentions { get; set; }
    
    
    
    
}
