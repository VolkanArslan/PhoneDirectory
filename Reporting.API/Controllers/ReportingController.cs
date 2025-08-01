using Microsoft.AspNetCore.Mvc;
using Reporting.Application.Interfaces;

namespace Reporting.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportingController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportingController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var reports = await _reportService.GetAllAsync(cancellationToken);
        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var report = await _reportService.GetByIdAsync(id, cancellationToken);
        return report == null ? NotFound() : Ok(report);
    }
}