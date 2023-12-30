using Domain.Repositories;
using Application.Services;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;
using WebApi.Services.Implement;
using WebApi.Utilities;

namespace WebApi.IOC;

public static class Dependency
{
    public static IServiceCollection DependencyInjections(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Add DbContext
        services.AddDbContext<BicicletasBdaContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        // Repository Injections


        services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IEstacionRepository, EstacionRepository>();

        // Service Injections
        services.AddScoped<IEstacionService, EstacionService>();

        // Applicion Injections
        services.AddScoped<IApplicationEstacion, ApplicationEstacion>();
        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
}
