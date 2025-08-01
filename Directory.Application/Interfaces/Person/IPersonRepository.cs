namespace Directory.Application.Interfaces.Person;

public interface IPersonRepository
{
    Task<Domain.Entities.Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.Entities.Person>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Domain.Entities.Person person, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.Entities.Person>> GetAllWithContactInfosAsync(CancellationToken cancellationToken);
}