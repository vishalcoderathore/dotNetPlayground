using DotNetAPI.Models;

namespace DotNetAPI.Data.Interfaces;

public interface IUserRespository
{
    Task AddUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserById(int userId);
    Task EditUserAsync(User user);
    Task DeleteUserAsync(User user);
}
