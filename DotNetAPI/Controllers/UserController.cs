using DotNetAPI.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Console;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    readonly DataContextDapper _dapper;

    public UserController(IConfiguration config)
    {
        WriteLine(config.GetConnectionString("DefaultConnection"));
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers/{testValue}")]
    public string[] GetUsers(string testValue)
    {
        string[] data = ["abc", "def", "xyz1234", testValue];
        return data;
    }
}
