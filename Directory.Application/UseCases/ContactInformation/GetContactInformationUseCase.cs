using Directory.Application.DTOs.ContactInformation;
using Directory.Application.Interfaces;
using Directory.Application.Interfaces.ContactInformation;

namespace Directory.Application.UseCases.ContactInformation;

public class GetContactInformationUseCase(IContactInformationRepository contactInformationRepository)
    : IGetContactInformationUseCase
{
    public async Task<List<ContactInformationResponse>> ExecuteAsync(Guid personId, CancellationToken cancellationToken)
    {
        var infos = await contactInformationRepository.GetByPersonIdAsync(personId, cancellationToken);
        return infos.Select(x => new ContactInformationResponse
        {
            Id = x.Id,
            PersonId = x.PersonId,
            Type = x.Type,
            Value = x.Value
        }).ToList();
    }
}