using Microsoft.AspNetCore.Mvc;
using Reporting.Application.Interfaces;

namespace Reporting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportingController(IReportService reportService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var reports = await reportService.GetAllAsync(cancellationToken);
        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var report = await reportService.GetByIdAsync(id, cancellationToken);
        return report == null ? NotFound() : Ok(report);
    }
}