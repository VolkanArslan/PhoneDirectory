using Microsoft.EntityFrameworkCore;
using Reporting.Application.DTOs;
using Reporting.Application.Interfaces;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Infrastructure.Services;

public class ReportService(ReportingDbContext context) : IReportService
{
    public async Task<List<ReportDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Reports
            .Select(r => new ReportDto
            {
                Id = r.Id,
                Location = r.Location,
                RequestedAt = r.RequestedAt,
                Status = r.Status.ToString()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<ReportDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var report = await context.Reports
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (report == null) return null;

        return new ReportDto
        {
            Id = report.Id,
            Location = report.Location,
            RequestedAt = report.RequestedAt,
            Status = report.Status.ToString()
        };
    }
}