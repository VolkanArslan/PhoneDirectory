namespace Directory.Application.Interfaces.Person;

public interface IDeletePersonUseCase
{
    Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}