using DotNetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPI.Data;

public class UserRepository
{
    private readonly DataContextEF _context;

    public UserRepository(DataContextEF context)
    {
        _context = context;
    }

    // Add a new user
    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    // Get all users
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    // Retrieve a single user by ID
    public async Task<User?> GetUserById(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
    }

    // Edit an existing user
    public async Task EditUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    // Delete a user by ID
    public async Task DeleteUserAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
