using Reporting.Domain.Common;
using Reporting.Domain.Enums;

namespace Reporting.Domain.Entities;

public class Report : AuditableEntity<Guid>
{
    public DateTime RequestedAt { get; set; }
    public ReportStatus Status { get; set; }
    public string Location { get; set; } = string.Empty;
    public int PersonCount { get; set; }
    public int PhoneNumberCount { get; set; }
    public int EmailCount { get; set; }
}