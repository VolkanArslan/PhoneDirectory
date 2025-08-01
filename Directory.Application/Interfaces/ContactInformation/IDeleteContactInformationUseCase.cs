namespace Directory.Application.Interfaces.ContactInformation;

public interface IDeleteContactInformationUseCase
{
    Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken = default);
}