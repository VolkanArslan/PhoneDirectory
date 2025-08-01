using Directory.Application.Interfaces.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticsController(IGetStatisticsByLocationUseCase getStatisticsByLocationUseCase)
    : ControllerBase
{
    [HttpGet("{location}")]
    public async Task<IActionResult> GetStatisticsByLocation(string location, CancellationToken cancellationToken)
    {
        var stats = await getStatisticsByLocationUseCase.ExecuteAsync(location, cancellationToken);
        return Ok(stats);
    }
}