using Directory.Application.DTOs.ContactInformation;
using Directory.Application.Interfaces;

namespace Directory.Application.UseCases.ContactInformation;

public class CreateContactInformationUseCase : ICreateContactInformationUseCase
{
    private readonly IContactInformationRepository _contactInformationRepository;

    public CreateContactInformationUseCase(IContactInformationRepository contactInformationRepository)
    {
        _contactInformationRepository = contactInformationRepository;
    }

    public async Task<ContactInformationResponse> ExecuteAsync(CreateContactInformationRequest request, CancellationToken cancellationToken)
    {
        var info = new Domain.Entities.ContactInformation()
        {
            PersonId = request.PersonId,
            Type = request.Type,
            Value = request.Value
        };

        var created = await _contactInformationRepository.CreateAsync(info, cancellationToken);

        return new ContactInformationResponse
        {
            Id = created.Id,
            PersonId = created.PersonId,
            Type = created.Type,
            Value = created.Value
        };
    }
}