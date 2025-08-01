using Directory.Application.DTOs.Statistics;
using Directory.Application.Interfaces.Person;
using Directory.Application.Interfaces.Statistics;
using Directory.Domain.Enums;

namespace Directory.Application.UseCases.Statistics;

public class GetStatisticsByLocationUseCase(IPersonRepository personRepository) : IGetStatisticsByLocationUseCase
{
    public async Task<LocationStatisticsDto> ExecuteAsync(string location, CancellationToken cancellationToken)
    {
        var people = await personRepository.GetAllWithContactInfosAsync(cancellationToken);
        var peopleAtLocation = people.Where(p => p.ContactInformations.Any(ci => ci.Type == ContactType.Location && ci.Value == location)).ToList();

        var personCount = peopleAtLocation.Count;

        var phoneNumberCount = peopleAtLocation
            .SelectMany(p => p.ContactInformations)
            .Count(ci => ci.Type == ContactType.Phone);

        var emailCount = peopleAtLocation
            .SelectMany(p => p.ContactInformations)
            .Count(ci => ci.Type == ContactType.Email);

        return new LocationStatisticsDto
        {
            Location = location,
            PersonCount = personCount,
            PhoneNumberCount = phoneNumberCount,
            EmailCount = emailCount
        };
    }
}