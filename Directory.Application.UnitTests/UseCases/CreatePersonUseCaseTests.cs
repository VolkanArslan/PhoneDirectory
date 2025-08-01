using Directory.Application.DTOs.Person;
using Directory.Application.Interfaces.Person;
using Directory.Application.UseCases.Person;
using Directory.Domain.Entities;
using Moq;

namespace Directory.Application.UnitTests.UseCases;

public class CreatePersonUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_CreatesPersonSuccessfully()
    {
        // Arrange
        var mockPersonRepository = new Mock<IPersonRepository>();
        mockPersonRepository.Setup(repo => repo.AddAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var useCase = new CreatePersonUseCase(mockPersonRepository.Object);

        var request = new CreatePersonRequest
        {
            FirstName = "Test",
            LastName = "User",
            Company = "TestCompany"
        };

        // Act
        var response = await useCase.ExecuteAsync(request, CancellationToken.None);

        // Assert
        Assert.NotNull(response);
        Assert.NotEqual(Guid.Empty, response.Id);
        mockPersonRepository.Verify(repo => repo.AddAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}