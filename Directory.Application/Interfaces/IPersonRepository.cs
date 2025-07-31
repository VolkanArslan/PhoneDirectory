using Directory.Domain.Entities;

namespace Directory.Application.Interfaces;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person);
    Task<Person?> GetByIdAsync(Guid id);
    Task<List<Person>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id);
}