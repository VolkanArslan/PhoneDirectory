namespace Reporting.Domain.Common;

public class AuditableEntity<T> : EntityBase<T>, IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}