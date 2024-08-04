using System;

namespace CSharpPracticesApp.Delegates
{
    public delegate void Print(string message);

    public static class DelegatesExample
    {
        public static void Run()
        {
            Print print = PrintMessage;
            print("Hello, Delegates!");

            // Using an anonymous method
            Print anonymousPrint = delegate(string msg)
            {
                Console.WriteLine("Anonymous: " + msg);
            };
            anonymousPrint("Hello, Anonymous Delegates!");

            // Using a lambda expression
            Print lambdaPrint = (msg) => Console.WriteLine("Lambda: " + msg);
            lambdaPrint("Hello, Lambda Delegates!");
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine("Message: " + message);
        }
    }
}
