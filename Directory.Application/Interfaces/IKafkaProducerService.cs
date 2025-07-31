namespace Directory.Application.Interfaces;

public interface IKafkaProducerService
{
    Task PublishReportRequestAsync(string location, CancellationToken cancellationToken);
}