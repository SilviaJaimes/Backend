using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
{
    public void Configure(EntityTypeBuilder<Carrito> builder)
    {

        builder.ToTable("carrito");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id);
        
        builder.HasOne(d => d.Cliente)
        .WithMany(d => d.Carritos)
        .HasForeignKey(d => d.IdClienteFk);

        builder.Property(p => p.Vendido)
        .HasColumnName("vendido")
        .HasColumnType("TINYINT(1)")
        .IsRequired();
    }
}