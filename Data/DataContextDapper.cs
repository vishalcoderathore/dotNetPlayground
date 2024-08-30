using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using dotNetPlayground.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace dotNetPlayground.Data
{
    public class DataContextDapper
    {
        private readonly string _connectionString;

        public DataContextDapper(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string is missing or empty.");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public int InsertComputer(Computer computer)
        {
            using (IDbConnection connection = CreateConnection())
            {
                string sqlString =
                    @"
                    INSERT INTO TutorialAppSchema.Computer(
                        Motherboard,
                        CPUCores,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES (
                        @Motherboard,
                        @CPUCores,
                        @HasWifi,
                        @HasLTE,
                        @ReleaseDate,
                        @Price,
                        @VideoCard
                    )";

                return connection.Execute(sqlString, computer);
            }
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            using (IDbConnection connection = CreateConnection())
            {
                string sqlSelect =
                    @"SELECT Computer.Motherboard,
                             Computer.CPUCores,
                             Computer.HasWifi,
                             Computer.HasLTE,
                             Computer.ReleaseDate,
                             Computer.Price,
                             Computer.VideoCard 
                      FROM TutorialAppSchema.Computer";
                return connection.Query<Computer>(sqlSelect);
            }
        }
    }
}
