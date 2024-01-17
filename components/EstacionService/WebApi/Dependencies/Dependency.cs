using System.Reflection;
using Estaciones.Application;
using Estaciones.Application.Common;
using Estaciones.Application.Services;
using Estaciones.Domain.Repositories;
using Estaciones.Domain.Services;
using Estaciones.Infrastructure.Context;
using Estaciones.Infrastructure.Repository;
using Estaciones.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApi.Utilities;

namespace WebApi.Dependencies;

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


        services.AddScoped<IEstacionRepository, EstacionRepository>();

        // Service Injections
        services.AddScoped<IEstacionService, EstacionService>();
        services.AddTransient(typeof(IDistributedCacheService), typeof(DistriutedCacheService));

        // Applicion Injections
        //services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
        });

        // Caching
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "redis-dev:6379";
        });

        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDbContextCheck<BicicletasBdaContext>();



        return services;
    }
}
