using Alquileres.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarifas.Domain;

namespace Shared.Infrastructure.Persistence.EntityConfigurations;

public class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
{
    public void Configure(EntityTypeBuilder<Alquiler> builder)
    {
        builder.ToTable("alquileres");

        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .HasColumnName("id")
            .HasConversion(v => v.Value, v => new AlquilerId(v))
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Cliente).HasColumnName("id_cliente");

        builder.Property(a => a.Estado).HasColumnName("estado").HasConversion<int>();

        builder
            .OwnsOne(a => a.EstacionRetiro)
            .Property(v => v.Value)
            .HasColumnName("estacion_retiro");

        builder
            .OwnsOne(a => a.EstacionDevolucion)
            .Property(v => v.Value)
            .HasColumnName("estacion_devolucion");

        builder
            .Property(a => a.FechaHoraRetiro)
            .HasColumnName("fecha_hora_retiro")
            .HasConversion(v => (DateTime)v, v => v.ToUniversalTime());

        builder
            .Property(a => a.FechaHoraDevolucion)
            .HasColumnName("fecha_hora_devolucion")
            //.HasConversion(v => v, v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : null);
            .HasConversion(v => v, v => v.HasValue ? v.Value.ToUniversalTime() : null);

        builder.OwnsOne(a => a.Monto).Property(v => v.Value).HasColumnName("monto");

        builder
            .Property(a => a.TarifaId)
            .HasColumnName("id_tarifa")
            .HasConversion(v => v.Value, v => new TarifaId(v));

        builder.HasOne(a => a.Tarifa)
            .WithMany()
        .HasForeignKey(a => a.TarifaId)
        //.IsRequired()
        ;
    }
}
