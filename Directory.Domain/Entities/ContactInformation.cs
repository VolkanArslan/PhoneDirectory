using Directory.Domain.Common;
using Directory.Domain.Enums;

namespace Directory.Domain.Entities;

public class ContactInformation : AuditableEntity<Guid>
{
    public required Guid PersonId { get; set; }
    public required ContactType Type { get; set; }
    public required string Value { get; set; }

    
    public Person? Person { get; set; }
}