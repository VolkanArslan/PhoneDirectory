using Directory.Application.Interfaces;
using Directory.Application.Interfaces.Person;

namespace Directory.Application.UseCases.Person;

public class DeletePersonUseCase : IDeletePersonUseCase
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonUseCase(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _personRepository.DeleteAsync(id, cancellationToken);
    }
}