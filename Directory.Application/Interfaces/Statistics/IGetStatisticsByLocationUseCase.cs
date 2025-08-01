using Directory.Application.DTOs.Statistics;

namespace Directory.Application.Interfaces.Statistics;

public interface IGetStatisticsByLocationUseCase
{
    Task<LocationStatisticsDto> ExecuteAsync(string location, CancellationToken cancellationToken);
}