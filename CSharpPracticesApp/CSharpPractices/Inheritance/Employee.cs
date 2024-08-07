namespace CSharpPractices.Inheritance;

public class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Department { get; set; }

    public Employee(string name, int id, string department)
    {
        Name = name;
        Id = id;
        Department = department;
    }

    public string GetHealthInsuranceAmount(){
        return "Health Insurance Amount is : " + 500;
    }

    public void DisplayEmployeeInfo()
    {
        Console.WriteLine($"Name: {Name}, Id: {Id}, Department: {Department}");
    }
}
