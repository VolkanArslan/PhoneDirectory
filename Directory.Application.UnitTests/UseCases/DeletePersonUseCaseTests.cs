using Directory.Application.Interfaces.Person;
using Directory.Application.UseCases.Person;
using Moq;

namespace Directory.Application.UnitTests.UseCases;

public class DeletePersonUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_DeletesPersonSuccessfully()
    {
        // Arrange
        var mockRepo = new Mock<IPersonRepository>();
        mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var useCase = new DeletePersonUseCase(mockRepo.Object);

        var id = Guid.NewGuid();

        // Act
        var result = await useCase.ExecuteAsync(id, CancellationToken.None);

        // Assert
        Assert.True(result);
        mockRepo.Verify(repo => repo.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}