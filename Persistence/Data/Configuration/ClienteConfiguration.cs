using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {

        builder.ToTable("cliente");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
        .HasColumnType("int")
        .HasMaxLength(11)
        .IsRequired();

        builder.Property(p => p.Documento)
        .HasColumnName("documento")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder.HasIndex(d => d.Documento)
        .IsUnique();

        builder.HasIndex(d => d.IdUsuarioFk)
        .IsUnique();
        

        builder.Property(p => p.PrimerNombre)
        .HasColumnName("primerNombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.SegundoNombre)
        .HasColumnName("segundoNombre")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.PrimerApellido)
        .HasColumnName("primerApellido")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.SegundoApellido)
        .HasColumnName("segundoApellido")
        .HasColumnType("varchar")
        .HasMaxLength(150)
        .IsRequired();

        builder.Property(p => p.Telefono)
        .HasColumnName("telefono")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("email")
        .HasColumnType("varchar")
        .HasMaxLength(250)
        .IsRequired();

        builder.HasOne(d => d.Usuario)
        .WithMany(d => d.Clientes)
        .HasForeignKey(d => d.IdUsuarioFk);
    }
}