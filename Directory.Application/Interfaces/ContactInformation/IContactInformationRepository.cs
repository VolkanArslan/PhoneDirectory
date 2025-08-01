namespace Directory.Application.Interfaces.ContactInformation;

public interface IContactInformationRepository
{
    Task<Domain.Entities.ContactInformation> CreateAsync(Domain.Entities.ContactInformation info, CancellationToken cancellationToken);
    Task<List<Domain.Entities.ContactInformation>> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}