using Microsoft.EntityFrameworkCore;
using Reporting.Application.DTOs.Consumer;
using Reporting.Domain.Enums;
using Reporting.Infrastructure.Kafka;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Application.UnitTests.Services;

public class ReportMessageHandlerTests
{
    [Fact]
    public async Task HandleAsync_AddsReportToDb()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ReportingDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        using var dbContext = new ReportingDbContext(options);

        var handler = new ReportMessageHandler(dbContext);
        var dto = new ReportRequestDto { Location = "Trabzon" };

        // Act
        await handler.HandleAsync(dto, CancellationToken.None);

        // Assert
        var report = dbContext.Reports.FirstOrDefault(r => r.Location == "Trabzon");
        Assert.NotNull(report);
        Assert.Equal("Trabzon", report.Location);
        Assert.Equal(ReportStatus.Preparing, report.Status);
    }
}