namespace CSharpPractices.Inheritance;

public class Manager : Employee
{
    public String Region { set; get; }

    public Manager(string name, int id, string department, string region)
        : base(name, id, department)
    {
        Region = region;
    }

    // Method Hiding 
    // Use the new keyword to hide the parent class implementation
    public new string GetHealthInsuranceAmount(){
        return "Health Insurance Amount is : " + 1000;
    }

    public void DisplayManagerInfo()
    {
        DisplayEmployeeInfo();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine(GetHealthInsuranceAmount());

    }
}
