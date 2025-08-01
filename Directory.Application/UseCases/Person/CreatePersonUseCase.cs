using Directory.Application.DTOs;
using Directory.Application.DTOs.Person;
using Directory.Application.Interfaces;
using Directory.Application.Interfaces.Person;

namespace Directory.Application.UseCases.Person;

public class CreatePersonUseCase(IPersonRepository personRepository) : ICreatePersonUseCase
{
    public async Task<CreatePersonResponse> ExecuteAsync(CreatePersonRequest request, CancellationToken cancellationToken = default)
    {
        var person = new Domain.Entities.Person
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Company = request.Company
        };
        
        await personRepository.AddAsync(person, cancellationToken);

        return new CreatePersonResponse
        {
            Id = person.Id
        };
    }
}