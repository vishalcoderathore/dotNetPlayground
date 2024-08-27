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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlCommand = "SELECT GETDATE()";
                    DateTime rightNow = connection.QuerySingle<DateTime>(sqlCommand);
                    Console.WriteLine(rightNow);

                    Console.WriteLine("Connection successful!");
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
