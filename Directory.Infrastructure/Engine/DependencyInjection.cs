using Directory.Application.Interfaces;
using Directory.Infrastructure.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Directory.Infrastructure.Engine;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IKafkaProducerService, KafkaProducerService>();
        
        return services;
    }
}