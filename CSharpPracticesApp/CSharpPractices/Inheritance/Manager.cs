namespace CSharpPractices.Inheritance;

public class Manager : Employee
{
    public String Region { set; get; }

    public Manager(string name, int id, string department, string region)
        : base(name, id, department)
    {
        Region = region;
    }

    public void DisplayManagerInfo()
    {
        DisplayEmployeeInfo();
        Console.WriteLine($"Region: {Region}");
    }
}
