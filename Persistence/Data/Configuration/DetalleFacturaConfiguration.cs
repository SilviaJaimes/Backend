using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
{
    public void Configure(EntityTypeBuilder<DetalleFactura> builder)
    {

        builder.ToTable("detalleFactura");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .HasColumnType("int")
        .HasMaxLength(11)
        .IsRequired();

        builder.HasOne(d => d.CarritoProducto)
        .WithMany(d => d.DetalleFacturas)
        .HasForeignKey(d => d.IdCarritoProductoFk);

        builder.HasOne(d => d.Factura)
        .WithMany(d => d.DetalleFacturas)
        .HasForeignKey(d => d.IdFacturaFk);

        builder.Property(p => p.PrecioUnitario)
        .HasColumnName("precioUnitario")
        .HasColumnType("decimal(11,2)")
        .HasMaxLength(300)
        .IsRequired();

        builder.Property(p => p.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(50)
        .IsRequired();
    }
}