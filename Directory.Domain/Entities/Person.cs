using Directory.Domain.Common;

namespace Directory.Domain.Entities;

public class Person : AuditableEntity<Guid>
{
    public required string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    
    public ICollection<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
}