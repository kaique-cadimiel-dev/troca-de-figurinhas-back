using FluentAssertions;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Enums;

namespace TrocaDeFigurinhas.Tests.Unit.Models;

public class TradeSpotTests
{
    [Fact]
    public void TradeSpot_ShouldBeCreated_WithValidData()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Central Park Spot";
        var address = "5th Ave, New York, NY 10022";
        var lat = 40.785091f;
        var lng = -73.968285f;
        var whatsapp = "123456789";
        var photoUrl = "https://example.com/spot.png";
        var days = new[] { "MON", "WED", "FRI" };
        var openTime = new TimeOnly(9, 0);
        var closeTime = new TimeOnly(18, 0);
        var status = TradeSpotStatus.Active;
        var reportedBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;

        // Act
        var spot = new TradeSpot
        {
            Id = id,
            Name = name,
            Address = address,
            Lat = lat,
            Lng = lng,
            Whatsapp = whatsapp,
            PhotoUrl = photoUrl,
            Days = days,
            OpenTime = openTime,
            CloseTime = closeTime,
            Status = status,
            ReportedBy = reportedBy,
            CreatedAt = createdAt
        };

        // Assert
        spot.Id.Should().Be(id);
        spot.Name.Should().Be(name);
        spot.Address.Should().Be(address);
        spot.Lat.Should().Be(lat);
        spot.Lng.Should().Be(lng);
        spot.Whatsapp.Should().Be(whatsapp);
        spot.PhotoUrl.Should().Be(photoUrl);
        spot.Days.Should().BeEquivalentTo(days);
        spot.OpenTime.Should().Be(openTime);
        spot.CloseTime.Should().Be(closeTime);
        spot.Status.Should().Be(status);
        spot.ReportedBy.Should().Be(reportedBy);
        spot.CreatedAt.Should().Be(createdAt);
    }
}
