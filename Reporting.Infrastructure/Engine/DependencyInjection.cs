using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reporting.Application.Interfaces;
using Reporting.Infrastructure.Kafka;
using Reporting.Infrastructure.Services;

namespace Reporting.Infrastructure.Engine;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IReportMessageHandler, ReportMessageHandler>();

        return services;
    }
}