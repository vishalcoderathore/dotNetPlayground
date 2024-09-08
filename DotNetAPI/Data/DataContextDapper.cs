using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotNetAPI.Data;

public class DataContextDapper
{
    private readonly IConfiguration _config;
    private const string DB_CONNECTION = "DefaultConnection";

    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
        using (
            IDbConnection dbConnection = new SqlConnection(
                _config.GetConnectionString(DB_CONNECTION)
            )
        )
        {
            return dbConnection.Query<T>(sql);
        }
    }

    public T LoadDataSingle<T>(string sql)
    {
        using (
            IDbConnection dbConnection = new SqlConnection(
                _config.GetConnectionString(DB_CONNECTION)
            )
        )
        {
            return dbConnection.QuerySingle<T>(sql);
        }
    }

    public bool ExecuteSql(string sql)
    {
        using (
            IDbConnection dbConnection = new SqlConnection(
                _config.GetConnectionString(DB_CONNECTION)
            )
        )
        {
            return dbConnection.Execute(sql) > 0;
        }
    }

    public int ExecuteSqlWithRowCount(string sql)
    {
        using (
            IDbConnection dbConnection = new SqlConnection(
                _config.GetConnectionString(DB_CONNECTION)
            )
        )
        {
            return dbConnection.Execute(sql);
        }
    }
}
