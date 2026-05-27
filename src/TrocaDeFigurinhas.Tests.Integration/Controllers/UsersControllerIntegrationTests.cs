using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Tests.Integration.Controllers;

public class UsersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public UsersControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateUser_ShouldReturnCreated_WhenDataIsValid()
    {
        // Arrange
        var user = new User
        {
            Name = "Integration Test User",
            Email = $"test_{Guid.NewGuid()}@example.com",
            Password = "password123"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/users", user);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdUser = await response.Content.ReadFromJsonAsync<User>();
        createdUser.Should().NotBeNull();
        createdUser!.Email.Should().Be(user.Email);
        createdUser.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public async Task GetUser_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        // Act
        var response = await _client.GetAsync($"/api/users/{Guid.NewGuid()}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
