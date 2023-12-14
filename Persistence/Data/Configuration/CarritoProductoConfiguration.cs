using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CarritoProductoConfiguration : IEntityTypeConfiguration<CarritoProducto>
{
    public void Configure(EntityTypeBuilder<CarritoProducto> builder)
    {

        builder.ToTable("carritoProducto");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id);
        
        builder.HasOne(d => d.Carrito)
        .WithMany(d => d.CarritoProductos)
        .HasForeignKey(d => d.IdCarritoFk);

        builder.HasOne(d => d.Producto)
        .WithMany(d => d.CarritoProductos)
        .HasForeignKey(d => d.IdProductoFk);

        builder.Property(p => p.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(50)
        .IsRequired();
    }
}