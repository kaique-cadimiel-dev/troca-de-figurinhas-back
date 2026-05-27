using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var existingUser = await _userRepository.GetByEmailAsync(user.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Email already in use");
        }

        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.UtcNow;
        
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }
}
