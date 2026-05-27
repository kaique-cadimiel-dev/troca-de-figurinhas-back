using Moq;
using FluentAssertions;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Services;
using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Tests.Unit.Services;

public class TradeSpotServiceTests
{
    private readonly Mock<ITradeSpotRepository> _tradeSpotRepositoryMock;
    private readonly TradeSpotService _tradeSpotService;

    public TradeSpotServiceTests()
    {
        _tradeSpotRepositoryMock = new Mock<ITradeSpotRepository>();
        _tradeSpotService = new TradeSpotService(_tradeSpotRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateTradeSpotAsync_ShouldCreateSpot_WithActiveStatus()
    {
        // Arrange
        var spot = new TradeSpot
        {
            Name = "New Spot",
            Address = "Address 123"
        };

        // Act
        var result = await _tradeSpotService.CreateTradeSpotAsync(spot);

        // Assert
        result.Should().NotBeNull();
        result.Status.Should().Be(TradeSpotStatus.Active);
        _tradeSpotRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<TradeSpot>()), Times.Once);
    }

    [Fact]
    public async Task CreateTradeSpotAsync_ShouldThrowException_WhenNameIsEmpty()
    {
        // Arrange
        var spot = new TradeSpot
        {
            Name = "",
            Address = "Address 123"
        };

        // Act & Assert
        await _tradeSpotService.Invoking(s => s.CreateTradeSpotAsync(spot))
            .Should().ThrowAsync<ArgumentException>()
            .WithMessage("Name cannot be empty");
    }
}
