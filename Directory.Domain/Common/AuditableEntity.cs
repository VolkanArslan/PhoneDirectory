namespace Directory.Domain.Common;

public abstract  class AuditableEntity<TId> : EntityBase<TId>, IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}