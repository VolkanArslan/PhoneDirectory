using Directory.Application.DTOs.ContactInformation;

namespace Directory.Application.Interfaces.ContactInformation;

public interface ICreateContactInformationUseCase
{
    Task<ContactInformationResponse> ExecuteAsync(CreateContactInformationRequest request, CancellationToken cancellationToken);
}