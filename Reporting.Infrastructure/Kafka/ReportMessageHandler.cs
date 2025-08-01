using Reporting.Application.DTOs.Consumer;
using Reporting.Application.Interfaces;
using Reporting.Domain.Entities;
using Reporting.Domain.Enums;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Infrastructure.Kafka;

public class ReportMessageHandler : IReportMessageHandler
{
    private readonly ReportingDbContext _dbContext;

    public ReportMessageHandler(ReportingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task HandleAsync(ReportRequestDto dto, CancellationToken cancellationToken)
    {
        var report = new Report
        {
            Id = Guid.NewGuid(),
            Location = dto.Location ?? "Unknown",
            RequestedAt = DateTime.UtcNow,
            Status = ReportStatus.Preparing
        };
        _dbContext.Reports.Add(report);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}