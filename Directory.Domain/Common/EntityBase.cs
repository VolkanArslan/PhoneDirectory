namespace Directory.Domain.Common;

public abstract class EntityBase<TId>
{
    public TId Id { get; set; }
}