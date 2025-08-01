using Microsoft.EntityFrameworkCore;
using Reporting.Infrastructure;
using Reporting.Infrastructure.Kafka;
using Reporting.Infrastructure.Persistence;

namespace Reporting.API.Engine;

public static class DependencyInjection
{
    public static IServiceCollection AddServies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReportingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddHostedService<ReportRequestConsumer>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}