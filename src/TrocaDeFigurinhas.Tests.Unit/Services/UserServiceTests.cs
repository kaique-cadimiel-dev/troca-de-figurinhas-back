using Moq;
using FluentAssertions;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Services;

namespace TrocaDeFigurinhas.Tests.Unit.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _authServiceMock = new Mock<IAuthService>();
        _userService = new UserService(_userRepositoryMock.Object, _authServiceMock.Object);
    }

    [Fact]
    public async Task CreateUserAsync_ShouldCreateUser_WhenEmailIsUnique()
    {
        // Arrange
        var user = new User
        {
            Name = "John Doe",
            Email = "john@example.com",
            Password = "password123"
        };

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(user.Email))
            .ReturnsAsync((User?)null);
        
        _authServiceMock.Setup(auth => auth.HashPassword(It.IsAny<string>()))
            .Returns("hashed_password");

        // Act
        var result = await _userService.CreateUserAsync(user);

        // Assert
        result.Should().NotBeNull();
        result.Email.Should().Be(user.Email);
        _userRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task CreateUserAsync_ShouldThrowException_WhenEmailAlreadyExists()
    {
        // Arrange
        var user = new User
        {
            Name = "John Doe",
            Email = "john@example.com",
            Password = "password123"
        };

        _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(user.Email))
            .ReturnsAsync(new User());

        // Act & Assert
        await _userService.Invoking(s => s.CreateUserAsync(user))
            .Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Email already in use");
    }
}
