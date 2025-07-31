using Directory.Application.Interfaces;
using Directory.Infrastructure.Persistence;
using Directory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Directory.API.Engine;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}