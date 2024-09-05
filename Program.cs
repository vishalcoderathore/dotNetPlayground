using System;
using dotNetPlayground.Data;
using dotNetPlayground.Models;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace dotNetPlayground
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task firstTask = new Task(() =>
            {
                Thread.Sleep(100);
                WriteLine("Task 1 (100ms)");
            });

            Task secondTask = ConsoleAfterDelayAsync("Task 2 (150ms)", 150);

            ConsoleAfterDelay("Delay", 101);

            Task thirdTask = ConsoleAfterDelayAsync("Task 3 (50ms)", 50);

            firstTask.Start();
            WriteLine("After the task was created");
            await firstTask;

            await secondTask;
            await thirdTask;
        }

        static void ConsoleAfterDelay(string text, int delay)
        {
            Thread.Sleep(delay);
            WriteLine(text);
        }

        static async Task ConsoleAfterDelayAsync(string text, int delay)
        {
            await Task.Delay(delay);
            WriteLine(text);
        }
    }
}
