using AutoMapper;
using DotNetAPI.Data;
using DotNetAPI.Data.Interfaces;
using DotNetAPI.Dtos;
using DotNetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    private readonly IUserRespository _userRepository;
    private readonly IMapper _mapper;

    public UserEFController(IUserRespository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet("GetUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();
        if (!users.Any())
        {
            return NoContent();
        }

        return Ok(users);
    }

    [HttpGet("GetSingleUser/{userId}")]
    public async Task<ActionResult<User>> GetSingleUser(int userId)
    {
        User? user = await _userRepository.GetUserById(userId);
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
        var existingUser = await _userRepository.GetUserById(user.UserId);

        if (existingUser == null)
        {
            return NotFound($"User with ID {user.UserId} not found.");
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Gender = user.Gender;
        existingUser.Active = user.Active;

        try
        {
            await _userRepository.EditUserAsync(existingUser);
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
            var user = _mapper.Map<User>(userDto);

            // Use the repository to add the user
            await _userRepository.AddUserAsync(user);

            return CreatedAtAction(nameof(GetSingleUser), new { userId = user.UserId }, user);
        }
        catch (Exception ex)
        {
            // Log the exception (if needed)
            return BadRequest("An error occurred while adding the new user." + ex);
        }
    }

    [HttpDelete("DeleteUser/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            // Find the user in the database
            var user = await _userRepository.GetUserById(userId);

            // If user not found, return 404 Not Found
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            // Remove the user from the database
            await _userRepository.DeleteUserAsync(user);

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
