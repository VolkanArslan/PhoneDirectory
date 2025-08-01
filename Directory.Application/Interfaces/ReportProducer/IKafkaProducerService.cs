namespace Directory.Application.Interfaces.ReportProducer;

public interface IKafkaProducerService
{
    Task PublishReportRequestAsync(string location, CancellationToken cancellationToken);
}