using Directory.Application.DTOs.Report;
using Directory.Application.Interfaces;
using Directory.Application.Interfaces.ReportProducer;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

[ApiController]
[Route("api/report-requests")]
public class ReportRequestController(IKafkaProducerService kafkaProducerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReportRequest request, CancellationToken cancellationToken)
    {
        await kafkaProducerService.PublishReportRequestAsync(request.Location, cancellationToken);
        return Accepted();
    }
}