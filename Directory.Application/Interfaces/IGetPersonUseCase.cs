using Directory.Domain.Entities;

namespace Directory.Application.Interfaces;

public interface IGetPersonUseCase
{
    Task<Person?> GetByIdPerson(Guid id, CancellationToken cancellationToken);
    Task<List<Person>> GetAllPersons(CancellationToken cancellationToken);
}