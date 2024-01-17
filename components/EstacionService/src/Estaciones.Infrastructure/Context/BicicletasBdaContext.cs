using Estaciones.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Estaciones.Infrastructure.Context;

public partial class BicicletasBdaContext : DbContext
{
    public BicicletasBdaContext() { }

    public BicicletasBdaContext(DbContextOptions<BicicletasBdaContext> options)
        : base(options) { }

    public virtual DbSet<Estacion> Estaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estaciones_pkey");

            entity.ToTable("estaciones");

            entity.Property(e => e.Id).HasColumnName("id")
            .HasConversion(v => v.Value, v => new EstacionId(v))
            .ValueGeneratedOnAdd();
            entity
                .Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_creacion")
                .HasConversion(v => v.ToLocalTime(), v => v.ToUniversalTime());
            entity.OwnsOne(e => e.Latitud)
                .Property(v => v.Value)
                .HasColumnName("latitud");
            entity.OwnsOne(e => e.Longitud)
                .Property(v => v.Value)
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
