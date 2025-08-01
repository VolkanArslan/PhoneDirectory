using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reporting.Application.DTOs.Consumer;
using Reporting.Domain.Entities;
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

                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ReportingDbContext>();

                    var report = new Report
                    {
                        Id = Guid.NewGuid(),
                        Location = reportRequest?.Location ?? "Unknown",
                        RequestedAt = DateTime.UtcNow,
                        Status = ReportStatus.Preparing
                    };

                    db.Reports.Add(report);
                    await db.SaveChangesAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                // logger
            }
        }
    }
}