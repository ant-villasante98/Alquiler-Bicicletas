
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence.EntityConfigurations;
using Tarifas.Domain;

namespace Tarifas.Shared.Infrastructure.Persistence;

public class AlquilerContext : DbContext
{
    public AlquilerContext() { }

    public AlquilerContext(DbContextOptions<AlquilerContext> options)
    : base(options) { }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TarifaConfiguration());
    }
}