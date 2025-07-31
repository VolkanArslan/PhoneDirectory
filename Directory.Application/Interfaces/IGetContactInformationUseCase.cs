using Directory.Application.DTOs.ContactInformation;

namespace Directory.Application.Interfaces;

public interface IGetContactInformationUseCase
{
    Task<List<ContactInformationResponse>> ExecuteAsync(Guid personId, CancellationToken cancellationToken);
}