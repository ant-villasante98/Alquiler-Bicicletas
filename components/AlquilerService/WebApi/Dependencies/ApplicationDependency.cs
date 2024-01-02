
using Microsoft.EntityFrameworkCore;
using Tarifas.Application;
using Tarifas.Application.Common;
using Tarifas.Domain.Repositories;
using Tarifas.Domain.Services;
using Tarifas.Infrastructure;
using Tarifas.Shared.Infrastructure.Persistence;

namespace WebApi.Dependencies;
public static class ApplicationDependency
{
    public static IServiceCollection ApplicationDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AlquilerContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("PostgresDB"))
        );

        services.AddScoped<ITarifaService, TarifaService>();
        services.AddScoped<ITarifaRepository, TarifaRepository>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<TarifaAssemblyReference>();
        }
        );


        return services;
    }
}