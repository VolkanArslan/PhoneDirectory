using System.Text.Json;
using Confluent.Kafka;
using Directory.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Directory.Infrastructure.Kafka;

public class KafkaProducerService : IKafkaProducerService
{
    private readonly IConfiguration _configuration;

    public KafkaProducerService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task PublishReportRequestAsync(string location, CancellationToken cancellationToken)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };

        var message = new
        {
            Location = location
        };

        using var producer = new ProducerBuilder<Null, string>(config).Build();
        var json = JsonSerializer.Serialize(message);

        await producer.ProduceAsync(
            _configuration["Kafka:ReportRequestTopic"],
            new Message<Null, string> { Value = json },
            cancellationToken
        );
    }
}