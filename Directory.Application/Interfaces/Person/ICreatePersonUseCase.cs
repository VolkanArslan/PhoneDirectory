using Directory.Application.DTOs;
using Directory.Application.DTOs.Person;

namespace Directory.Application.Interfaces.Person;

public interface ICreatePersonUseCase
{
    Task<CreatePersonResponse> ExecuteAsync(CreatePersonRequest request, CancellationToken cancellationToken = default);
}