using Directory.Application.DTOs;

namespace Directory.Application.Interfaces;

public interface ICreatePersonUseCase
{
    Task<CreatePersonResponse> ExecuteAsync(CreatePersonRequest request, CancellationToken cancellationToken = default);
}