using Directory.Application.Interfaces;
using Directory.Application.Interfaces.Person;

namespace Directory.Application.UseCases.Person;

public class GetPersonUseCase : IGetPersonUseCase
{
    private readonly IPersonRepository _personRepository;

    public GetPersonUseCase(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Domain.Entities.Person?> GetByIdPerson(Guid id, CancellationToken cancellationToken)
    {
        return await _personRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<List<Domain.Entities.Person>> GetAllPersons(CancellationToken cancellationToken)
    {
        return await _personRepository.GetAllAsync(cancellationToken);
    }
}