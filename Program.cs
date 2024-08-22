using System.Diagnostics.Contracts;

namespace dotNetPlayground
{
    public class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            Console.Write("Write");
            Console.Write("Write2");
            Console.WriteLine("WriteLine");
            Console.Write("Write");
            Console.Write("Write2");
        }
    }
}
