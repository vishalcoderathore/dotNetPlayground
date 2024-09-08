using DotNetAPI.Data;
using DotNetAPI.Models;
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

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        string sql =
            @"
            SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            from TutorialAppSchema.Users
        ";
        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;
    }

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        string sql =
            @"
        SELECT * FROM TutorialAppSchema.Users where UserId = '"
            + userId
            + "';";
        User user = _dapper.LoadDataSingle<User>(sql);
        return user;
    }
}
