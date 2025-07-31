using Directory.Application.Interfaces;

namespace Directory.Application.UseCases.ContactInformation;

public class DeleteContactInformationUseCase : IDeleteContactInformationUseCase
{
    private readonly IContactInformationRepository _contactInformationRepository;

    public DeleteContactInformationUseCase(IContactInformationRepository contactInformationRepository)
    {
        _contactInformationRepository = contactInformationRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _contactInformationRepository.DeleteAsync(id, cancellationToken);
    }
}