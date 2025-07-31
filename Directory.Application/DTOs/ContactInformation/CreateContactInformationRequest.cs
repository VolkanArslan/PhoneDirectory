using Directory.Domain.Enums;

namespace Directory.Application.DTOs.ContactInformation;

public class CreateContactInformationRequest
{
    public required Guid PersonId { get; set; }
    public required ContactType Type { get; set; }
    public required string Value { get; set; }
}