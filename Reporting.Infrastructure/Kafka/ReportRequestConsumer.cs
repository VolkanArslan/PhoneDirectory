using System.Net.Http.Json;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reporting.Application.DTOs.Consumer;
using Reporting.Application.DTOs.Statistics;
using Reporting.Application.Interfaces;
using Reporting.Domain.Enums;
using Reporting.Infrastructure.Persistence;

namespace Reporting.Infrastructure.Kafka;

public class ReportRequestConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = "reporting-service",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(configuration["Kafka:ReportRequestTopic"]);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(stoppingToken);
                if (consumeResult == null) continue;

                var reportRequest = JsonSerializer.Deserialize<ReportRequestDto>(consumeResult.Message.Value);

                using var scope = serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<IReportMessageHandler>();

                if (reportRequest != null)
                    await handler.HandleAsync(reportRequest, stoppingToken);
            }
            catch (Exception ex)
            {
                // logger
                Console.WriteLine($"Kafka consumer error: {ex.Message}");
            }
        }
    }
    
    private async Task<ReportStatisticsDto?> GetLocationStatisticsAsync(string location, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var url = $"https://localhost:44364/api/statistics/{location}";
        return await httpClient.GetFromJsonAsync<ReportStatisticsDto>(url, cancellationToken);
    }
}