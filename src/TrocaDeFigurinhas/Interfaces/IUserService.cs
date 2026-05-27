using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Interfaces;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
}
