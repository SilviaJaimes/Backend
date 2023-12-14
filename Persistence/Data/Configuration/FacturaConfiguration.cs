using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {

        builder.ToTable("factura");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .HasColumnType("int")
        .HasMaxLength(11)
        .IsRequired();

        builder.Property(p => p.PrecioTotal)
        .HasColumnName("precioTotal")
        .HasColumnType("decimal(11,2)")
        .HasMaxLength(300)
        .IsRequired();

        builder.Property(p => p.CantidadTotal)
        .HasColumnName("cantidadTotal")
        .HasColumnType("int")
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(d => d.Cliente)
        .WithMany(d => d.Facturas)
        .HasForeignKey(d => d.IdClienteFk);
    }
}