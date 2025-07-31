using Directory.Domain.Entities;

namespace Directory.Application.Interfaces;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person);
    Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Person>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Person person, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}