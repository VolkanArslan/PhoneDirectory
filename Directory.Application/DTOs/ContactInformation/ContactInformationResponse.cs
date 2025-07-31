using Directory.Domain.Enums;

namespace Directory.Application.DTOs.ContactInformation;

public class ContactInformationResponse
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public ContactType Type { get; set; }
    public string Value { get; set; }
}