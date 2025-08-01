using Reporting.Application.DTOs;

namespace Reporting.Application.Interfaces;

public interface IReportService
{
    Task<List<ReportDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ReportDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}