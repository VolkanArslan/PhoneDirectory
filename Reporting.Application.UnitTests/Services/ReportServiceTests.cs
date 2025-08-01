using Microsoft.EntityFrameworkCore;
using Reporting.Domain.Entities;
using Reporting.Domain.Enums;
using Reporting.Infrastructure.Persistence;
using Reporting.Infrastructure.Services;

namespace Reporting.Application.UnitTests.Services;

public class ReportServiceTests
{
    private ReportingDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ReportingDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var dbContext = new ReportingDbContext(options);

        // Seed test data
        dbContext.Reports.Add(new Report
        {
            Id = Guid.NewGuid(),
            Location = "Artvin",
            RequestedAt = DateTime.UtcNow,
            Status = ReportStatus.Completed,
            PersonCount = 2,
            PhoneNumberCount = 3,
            EmailCount = 1
        });

        dbContext.Reports.Add(new Report
        {
            Id = Guid.NewGuid(),
            Location = "Ankara",
            RequestedAt = DateTime.UtcNow,
            Status = ReportStatus.Preparing,
            PersonCount = 1,
            PhoneNumberCount = 1,
            EmailCount = 0
        });

        dbContext.SaveChanges();
        return dbContext;
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllReports()
    {
        // Arrange
        using var dbContext = CreateInMemoryDbContext();
        var service = new ReportService(dbContext);

        // Act
        var result = await service.GetAllAsync(CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectReport()
    {
        // Arrange
        using var dbContext = CreateInMemoryDbContext();
        var target = await dbContext.Reports.FirstAsync();
        var service = new ReportService(dbContext);

        // Act
        var result = await service.GetByIdAsync(target.Id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(target.Id, result.Id);
        Assert.Equal(target.Location, result.Location);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
    {
        // Arrange
        using var dbContext = CreateInMemoryDbContext();
        var service = new ReportService(dbContext);

        // Act
        var result = await service.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public async Task GetAllAsync_ReturnsEmptyList_WhenNoReports()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ReportingDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var dbContext = new ReportingDbContext(options);
        var service = new ReportService(dbContext);

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenIdDoesNotExist()
    {
        var options = new DbContextOptionsBuilder<ReportingDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var dbContext = new ReportingDbContext(options);
        var service = new ReportService(dbContext);

        var result = await service.GetByIdAsync(Guid.NewGuid());

        Assert.Null(result);
    }
}