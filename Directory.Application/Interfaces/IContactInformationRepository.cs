using Directory.Domain.Entities;

namespace Directory.Application.Interfaces;

public interface IContactInformationRepository
{
    Task<ContactInformation> CreateAsync(ContactInformation info, CancellationToken cancellationToken);
    Task<List<ContactInformation>> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}