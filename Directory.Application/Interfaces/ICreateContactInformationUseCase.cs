using Directory.Application.DTOs.ContactInformation;

namespace Directory.Application.Interfaces;

public interface ICreateContactInformationUseCase
{
    Task<ContactInformationResponse> ExecuteAsync(CreateContactInformationRequest request, CancellationToken cancellationToken);
}