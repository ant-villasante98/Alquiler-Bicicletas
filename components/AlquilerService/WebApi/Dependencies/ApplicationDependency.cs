
using Alquileres.Application;
using Alquileres.Application.Common;
using Alquileres.Application.Create;
using Alquileres.Application.Finish;
using Alquileres.Application.GetAll;
using Alquileres.Domain;
using Alquileres.Domain.Services;
using Alquileres.Infrastructure.Repository;
using Alquileres.Infrastructure.Repository.Services;
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

        services.AddScoped<IAlquilerRepository, AlquilerRepository>();
        services.AddScoped<ICreateAlquiler, CreateAlquiler>();
        services.AddScoped<IEstacionService, EstacionService>();
        services.AddScoped<IFinishAlquiler, FinishAlquiler>();
        services.AddScoped<IGetAllAlquiler, GetAllAlquiler>();
        services.AddScoped<IAlquilerService, AlquilerService>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<TarifaAssemblyReference>();
            config.RegisterServicesFromAssemblyContaining<AlquilerAssemblyReference>();
        }
        );


        return services;
    }
}