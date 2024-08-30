using System;
using dotNetPlayground.Data;
using dotNetPlayground.Models;
using Microsoft.Extensions.Configuration;

namespace dotNetPlayground
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Build a configuration object to read from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Initialize the DataContextDapper with the configuration
            DataContextDapper dataContextDapper = new DataContextDapper(config);

            // Build Computer object
            Computer myComputer = new Computer(
                "ASUS Zephyrus",
                8,
                true,
                false,
                DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local),
                1700.00M,
                "RTX 4070"
            );

            try
            {
                // int result = dataContextDapper.InsertComputer(myComputer);
                // Console.WriteLine(result);

                IEnumerable<Computer> computers = dataContextDapper.GetAllComputers();
                foreach (Computer computer in computers)
                {
                    Console.WriteLine(computer.Motherboard);
                    Console.WriteLine(computer.CPUCores);
                    Console.WriteLine(computer.HasWifi);
                    Console.WriteLine(computer.ReleaseDate);
                    Console.WriteLine(computer.Price);
                    Console.WriteLine(computer.VideoCard);
                    Console.WriteLine(computer.HasLTE);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
