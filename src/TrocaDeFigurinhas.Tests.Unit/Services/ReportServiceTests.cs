using Moq;
using FluentAssertions;
using TrocaDeFigurinhas.Interfaces;
using TrocaDeFigurinhas.Models;
using TrocaDeFigurinhas.Services;

namespace TrocaDeFigurinhas.Tests.Unit.Services;

public class ReportServiceTests
{
    private readonly Mock<IReportRepository> _reportRepositoryMock;
    private readonly ReportService _reportService;

    public ReportServiceTests()
    {
        _reportRepositoryMock = new Mock<IReportRepository>();
        _reportService = new ReportService(_reportRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateReportAsync_ShouldCreateReport()
    {
        // Arrange
        var report = new Report
        {
            SpotId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Reason = "Test reason"
        };

        // Act
        var result = await _reportService.CreateReportAsync(report);

        // Assert
        result.Should().NotBeNull();
        result.Reason.Should().Be(report.Reason);
        _reportRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Report>()), Times.Once);
    }
}
