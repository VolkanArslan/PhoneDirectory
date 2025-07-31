using Directory.Application.Interfaces;
using Directory.Application.UseCases.ContactInformation;
using Directory.Application.UseCases.Person;
using Directory.Infrastructure.Persistence;
using Directory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Directory.API.Engine;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IContactInformationRepository, ContactInformationRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreatePersonUseCase, CreatePersonUseCase>();
        services.AddScoped<ICreateContactInformationUseCase, CreateContactInformationUseCase>();
        services.AddScoped<IDeleteContactInformationUseCase, DeleteContactInformationUseCase>();
        services.AddScoped<IDeletePersonUseCase, DeletePersonUseCase>();
        services.AddScoped<IGetPersonUseCase, GetPersonUseCase>();
        services.AddScoped<IGetContactInformationUseCase, GetContactInformationUseCase>();
        
        return services;
    }
}