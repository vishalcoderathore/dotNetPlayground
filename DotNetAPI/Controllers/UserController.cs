using Microsoft.AspNetCore.Mvc;
using static System.Console;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController(IConfiguration config)
    {
        WriteLine(config.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("GetUsers/{testValue}")]
    public string[] GetUsers(string testValue)
    {
        string[] data = ["abc", "def", "xyz1234", testValue];
        return data;
    }
}
