using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {

        builder.ToTable("producto");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .HasColumnType("int")
        .HasMaxLength(11)
        .IsRequired();

        builder.Property(p => p.Titulo)
        .HasColumnName("Titulo")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.Imagen)
        .HasColumnName("imagen")
        .HasColumnType("varchar")
        .HasMaxLength(300)
        .IsRequired();

        builder.HasOne(d => d.Categoria)
        .WithMany(d => d.Productos)
        .HasForeignKey(d => d.IdCategoriaFk);

        builder.Property(p => p.Precio)
        .HasColumnName("precio")
        .HasColumnType("decimal(11,2)")
        .HasMaxLength(300)
        .IsRequired();

        builder.Property(p => p.Stock)
        .HasColumnName("stock")
        .HasColumnType("int")
        .HasMaxLength(50)
        .IsRequired();
    }
}