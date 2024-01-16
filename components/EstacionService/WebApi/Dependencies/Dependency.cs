using System.Reflection;
using Application;
using Application.Common;
using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Services;
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
        services.AddTransient(typeof(IDistributedCacheService), typeof(EstacionDistriutedCache));

        // Applicion Injections
        services.AddAutoMapper(typeof(AutoMapperProfile));
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
