namespace Directory.Application.Interfaces.Person;

public interface IGetPersonUseCase
{
    Task<Domain.Entities.Person?> GetByIdPerson(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.Entities.Person>> GetAllPersons(CancellationToken cancellationToken);
}