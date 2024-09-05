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
                WriteLine("Task 1");
            });

            firstTask.Start();
            WriteLine("After the task was created");
            await firstTask;
        }
    }
}
