using DotNetAPI.Data;
using DotNetAPI.Dtos;
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

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql =
            $@"
        UPDATE TutorialAppSchema.Users
        SET 
            [FirstName] = '{user.FirstName}',
            [LastName] = '{user.LastName}',
            [Email] = '{user.Email}',
            [Gender] = '{user.Gender}',
            [Active] = '{user.Active}'
        WHERE UserId = {user.UserId};";

        bool isSuccess = _dapper.ExecuteSql(sql);

        if (isSuccess)
        {
            return Ok();
        }
        else
        {
            return BadRequest("User could not be updated.");
        }
    }

    [HttpPut("AddUser")]
    public IActionResult AddUser(UserToAddDto user)
    {
        // Manually constructing the SQL string with user data
        string sql =
            $@"
        INSERT INTO TutorialAppSchema.Users 
            ([FirstName], [LastName], [Email], [Gender], [Active])
        VALUES 
            ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Gender}', '{user.Active}');";

        // Executing the SQL string
        bool isSuccess = _dapper.ExecuteSql(sql);

        // Returning the appropriate response
        if (isSuccess)
        {
            return Ok("User added successfully.");
        }
        else
        {
            return BadRequest("Failed to add user.");
        }
    }
}
