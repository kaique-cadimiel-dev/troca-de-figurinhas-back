using FluentAssertions;
using TrocaDeFigurinhas.Models;

namespace TrocaDeFigurinhas.Tests.Unit.Models;

public class ReportTests
{
    [Fact]
    public void Report_ShouldBeCreated_WithValidData()
    {
        // Arrange
        var id = Guid.NewGuid();
        var spotId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var reason = "Inaccurate location";
        var createdAt = DateTime.UtcNow;

        // Act
        var report = new Report
        {
            Id = id,
            SpotId = spotId,
            UserId = userId,
            Reason = reason,
            CreatedAt = createdAt
        };

        // Assert
        report.Id.Should().Be(id);
        report.SpotId.Should().Be(spotId);
        report.UserId.Should().Be(userId);
        report.Reason.Should().Be(reason);
        report.CreatedAt.Should().Be(createdAt);
    }
}
