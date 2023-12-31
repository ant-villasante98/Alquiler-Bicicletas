﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

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

            entity.Property(e => e.Id).HasColumnName("ID");
            entity
                .Property(e => e.FechaHoraCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("FECHA_HORA_CREACION")
                .HasConversion(v => v.ToLocalTime(), v => v.ToUniversalTime());
            entity.Property(e => e.Latitud).HasColumnName("LATITUD");
            entity.Property(e => e.Longitud).HasColumnName("LONGITUD");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
