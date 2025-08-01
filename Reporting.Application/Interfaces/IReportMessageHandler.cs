using Reporting.Application.DTOs.Consumer;

namespace Reporting.Application.Interfaces;

public interface IReportMessageHandler
{
    Task HandleAsync(ReportRequestDto dto, CancellationToken cancellationToken);
}