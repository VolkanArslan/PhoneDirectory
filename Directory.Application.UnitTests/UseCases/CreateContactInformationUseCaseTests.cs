using Directory.Application.DTOs.ContactInformation;
using Directory.Application.Interfaces.ContactInformation;
using Directory.Application.UseCases.ContactInformation;
using Directory.Domain.Entities;
using Directory.Domain.Enums;
using Moq;

namespace Directory.Application.UnitTests.UseCases;

public class CreateContactInformationUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_CreatesContactInformationSuccessfully()
    {
        // Arrange
        var personId = Guid.NewGuid();
        var mockRepo = new Mock<IContactInformationRepository>();
        mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<ContactInformation>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ContactInformation
            {
                Id = Guid.NewGuid(),
                PersonId = personId,
                Type = ContactType.Phone,
                Value = "555-555-5555",
                Person = new Person { Id = personId, FirstName = "Volkan", LastName = "Arslan", Company = "KgTech" }
            });

        var useCase = new CreateContactInformationUseCase(mockRepo.Object);

        var request = new CreateContactInformationRequest
        {
            PersonId = Guid.NewGuid(),
            Type = ContactType.Phone,
            Value = "555-555-5555"
        };

        // Act
        var response = await useCase.ExecuteAsync(request, CancellationToken.None);

        // Assert
        Assert.NotNull(response);
        Assert.NotEqual(Guid.Empty, response.Id);
        mockRepo.Verify(repo => repo.CreateAsync(It.IsAny<ContactInformation>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}