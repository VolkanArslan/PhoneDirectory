namespace Directory.Application.Interfaces;

public interface IDeletePersonUseCase
{
    Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}