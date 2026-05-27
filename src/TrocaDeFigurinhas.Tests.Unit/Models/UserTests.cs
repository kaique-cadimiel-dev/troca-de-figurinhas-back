using FluentAssertions;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Tests.Unit.Models;

public class UserTests
{
    [Fact]
    public void User_ShouldBeCreated_WithValidData()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "John Doe";
        var email = "john@example.com";
        var password = "hashedpassword";
        var avatarUrl = "https://example.com/avatar.png";
        var createdAt = DateTime.UtcNow;

        // Act
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email,
            Password = password,
            AvatarUrl = avatarUrl,
            CreatedAt = createdAt
        };

        // Assert
        user.Id.Should().Be(id);
        user.Name.Should().Be(name);
        user.Email.Should().Be(email);
        user.Password.Should().Be(password);
        user.AvatarUrl.Should().Be(avatarUrl);
        user.CreatedAt.Should().Be(createdAt);
    }
}
