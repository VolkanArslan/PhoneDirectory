namespace Directory.Application.Interfaces;

public interface IDeleteContactInformationUseCase
{
    Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken = default);
}