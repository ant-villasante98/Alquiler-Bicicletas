
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarifas.Domain;

namespace Shared.Infrastructure.Persistence.EntityConfigurations;

public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
{
    public void Configure(EntityTypeBuilder<Tarifa> builder)
    {
        builder.ToTable("tarifas");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("id")
            .HasConversion(v => v.Value, v => new TarifaId(v))
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Definicion)
            .HasColumnName("definicion");

        builder.Property(t => t.TipoTarifa)
            .HasColumnName("tipo_tarifa");

        builder.OwnsOne(t => t.DiaSemana)
        .Property(x => x.Value)
        .HasColumnName("dia_semana");

        builder.OwnsOne(t => t.Fecha, fechaBuilder =>
        {
            fechaBuilder.Property(x => x.Dia)
            .HasColumnName("dia_mes");
            fechaBuilder.Property(x => x.Mes)
            .HasColumnName("mes");
            fechaBuilder.Property(x => x.Anio)
            .HasColumnName("anio");
        });

        builder.OwnsOne(t => t.MontoFijoAlquiler)
        .Property(x => x.Value)
        .HasColumnName("monto_fijo_alquiler");

        builder.OwnsOne(t => t.MontoHora)
        .Property(x => x.Value)
        .HasColumnName("monto_hora");

        builder.OwnsOne(t => t.MontoKm)
        .Property(x => x.Value)
        .HasColumnName("monto_km");

        builder.OwnsOne(t => t.MontoMinutoFraccion)
        .Property(x => x.Value)
        .HasColumnName("monto_minuto_fraccion");

    }
}