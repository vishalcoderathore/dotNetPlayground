using System;
using Dapper;
using dotNetPlayground.Models;
using Microsoft.Data.SqlClient;
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

            // Retrieve the connection string
            string? connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Connection string is missing or empty.");
                return;
            }

            // Build Computer object
            // Computer myComputer = new Computer(
            //     "ASUS Zephyrus",
            //     8,
            //     true,
            //     false,
            //     DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local),
            //     1700.00M,
            //     "RTX 4070"
            // );

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // string sqlString =
                    //     @"
                    //     INSERT INTO TutorialAppSchema.Computer(
                    //         Motherboard,
                    //         CPUCores,
                    //         HasWifi,
                    //         HasLTE,
                    //         ReleaseDate,
                    //         Price,
                    //         VideoCard
                    //     ) VALUES (
                    //         @Motherboard,
                    //         @CPUCores,
                    //         @HasWifi,
                    //         @HasLTE,
                    //         @ReleaseDate,
                    //         @Price,
                    //         @VideoCard
                    //     )";

                    // Console.WriteLine(sqlString);
                    // int result = connection.Execute(
                    //     sqlString,
                    //     new
                    //     {
                    //         myComputer.Motherboard,
                    //         myComputer.CPUCores,
                    //         myComputer.HasWifi,
                    //         myComputer.HasLTE,
                    //         myComputer.ReleaseDate,
                    //         myComputer.Price,
                    //         myComputer.VideoCard
                    //     }
                    // );
                    // Console.WriteLine(result);

                    string sqlSelect =
                        @"SELECT  Computer.Motherboard,
                            Computer.CPUCores,
                            Computer.HasWifi,
                            Computer.HasLTE,
                            Computer.ReleaseDate,
                            Computer.Price,
                            Computer.VideoCard 
                            FROM TutorialAppSchema.Computer";
                    IEnumerable<Computer> computers = connection.Query<Computer>(sqlSelect);
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
                catch (SqlException ex)
                {
                    Console.WriteLine(
                        "An error occurred while connecting to the database: " + ex.Message
                    );
                }
            }
        }
    }
}
