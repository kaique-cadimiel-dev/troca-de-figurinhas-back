using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Tests.Integration.Controllers;

public class TradeSpotsControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TradeSpotsControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateTradeSpot_ShouldReturnCreated_WhenDataIsValid()
    {
        // Arrange
        var user = new User { Name = "Reporter", Email = $"rep_{Guid.NewGuid()}@ex.com", Password = "123" };
        var userResponse = await _client.PostAsJsonAsync("/api/users", user);
        var createdUser = await userResponse.Content.ReadFromJsonAsync<User>();

        var spot = new TradeSpot
        {
            Name = "Integration Spot",
            Address = "Street 1",
            Lat = 1.0f,
            Lng = 2.0f,
            ReportedBy = createdUser!.Id,
            Days = new[] { "MON" }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/tradespots", spot);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdSpot = await response.Content.ReadFromJsonAsync<TradeSpot>();
        createdSpot.Should().NotBeNull();
        createdSpot!.Status.Should().Be(TradeSpotStatus.Active);
    }

    [Fact]
    public async Task GetTradeSpots_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("/api/tradespots");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
