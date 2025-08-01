using Directory.Application.Interfaces.Person;
using Directory.Application.UseCases.Statistics;
using Directory.Domain.Entities;
using Directory.Domain.Enums;
using Moq;

namespace Directory.Application.UnitTests.UseCases;

public class GetStatisticsByLocationUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_ReturnsCorrectStatistics()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var mockPersonRepository = new Mock<IPersonRepository>();
        mockPersonRepository.Setup(repo => repo.GetAllWithContactInfosAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Person>
            {
                new Person
                {
                    Id = personId,
                    FirstName = "Ali",
                    LastName = "Veli",
                    Company = "TestCorp",
                    ContactInformations = new List<ContactInformation>
                    {
                        new ContactInformation { PersonId = personId, Type = ContactType.Location, Value = "Ankara" },
                        new ContactInformation { PersonId = personId, Type = ContactType.Phone, Value = "5551112233" },
                        new ContactInformation { PersonId = personId, Type = ContactType.Email, Value = "xyz@hotmail.com" }
                    }
                }
            });

        var useCase = new GetStatisticsByLocationUseCase(mockPersonRepository.Object);

        // Act
        var result = await useCase.ExecuteAsync("Ankara", CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Ankara", result.Location);
        Assert.Equal(1, result.PersonCount);
        Assert.Equal(1, result.PhoneNumberCount);
        Assert.Equal(1, result.EmailCount);
    }
}