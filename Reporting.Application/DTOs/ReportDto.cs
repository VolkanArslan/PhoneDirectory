namespace Reporting.Application.DTOs;

public class ReportDto
{
    public Guid Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; }
    public string Status { get; set; } = string.Empty;
}