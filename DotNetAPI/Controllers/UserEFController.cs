using DotNetAPI.Data;
using DotNetAPI.Dtos;
using DotNetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    readonly DataContextEF _entityFramework;

    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

    [HttpGet("GetUsers")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _entityFramework.Users.ToList();
        if (users.Count == 0)
        {
            return NoContent(); // Return 204 No Content if no users are found
        }

        return Ok(users); // Return 200 OK with the list of users
    }

    [HttpGet("GetSingleUser/{userId}")]
    public ActionResult<User> GetSingleUser(int userId)
    {
        User? user = _entityFramework.Users.FirstOrDefault((u) => u.UserId == userId);
        if (user != null)
        {
            return Ok(user);
        }
        // Return a NotFound response if the user is not found
        return NotFound($"User with ID {userId} not found.");
    }

    [HttpPut("EditUser")]
    public async Task<ActionResult> EditUser(User user)
    {
        // Find the user in the database
        User? existingUser = await _entityFramework.Users.FirstOrDefaultAsync(u =>
            u.UserId == user.UserId
        );

        if (existingUser == null)
        {
            return NotFound($"User with ID {user.UserId} not found.");
        }

        // Update the user's properties
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Gender = user.Gender;
        existingUser.Active = user.Active;

        try
        {
            await _entityFramework.SaveChangesAsync();
            return Ok("User updated successfully.");
        }
        catch (Exception ex)
        {
            // Log the exception (ex) if needed
            return BadRequest("An error occurred while updating the user." + ex);
        }
    }

    [HttpPost("AddUser")]
    public async Task<ActionResult> AddUser(UserToAddDto userDto)
    {
        try
        {
            // Map the DTO to the User model
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Gender = userDto.Gender,
                Active = userDto.Active
            };

            // Add the new user to the Users DbSet
            await _entityFramework.Users.AddAsync(user);

            // Save the changes to the database
            await _entityFramework.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingleUser), new { userId = user.UserId }, user);
        }
        catch (Exception)
        {
            // Log the exception (if needed)
            return BadRequest("An error occurred while adding the new user.");
        }
    }

    [HttpDelete("DeleteUser/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            // Find the user in the database
            var user = await _entityFramework.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            // If user not found, return 404 Not Found
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            // Remove the user from the database
            _entityFramework.Users.Remove(user);

            // Save changes to the database
            await _entityFramework.SaveChangesAsync();

            return Ok($"User with ID {userId} deleted successfully.");
        }
        catch (Exception)
        {
            // Log the exception (if needed)
            return BadRequest(
                $"An error occurred while trying to delete the user with ID {userId}."
            );
        }
    }
}
