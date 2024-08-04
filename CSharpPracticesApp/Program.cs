using System;
using CSharpPractices.Delegates;
using CSharpPractices.Indexers;
using CSharpPractices.Inheritance;

namespace CSharpPracticesApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            RunExample("Indexer Example", IndexerExample.Run);
            RunExample("Delegate Example", DelegatesExample.Run);
            RunExample("Inheritance 1st Example", RunInheritanceExample);
        }

        static void RunExample(string title, Action exampleMethod)
        {
            var lineBreak = "---------------------------------------";

            Console.WriteLine(lineBreak);
            Console.WriteLine($"{title} : ");
            exampleMethod();
            Console.WriteLine(lineBreak);
            Console.WriteLine("");
        }

        static void RunInheritanceExample()
        {
            Employee emp = new Employee("John Doe", 123, "Engineering");
            emp.DisplayEmployeeInfo();

            Manager mgr = new Manager("Jane Smith", 456, "Sales", "North America");
            mgr.DisplayManagerInfo();
        }
    }
}
