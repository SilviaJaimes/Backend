using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {}
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<CarritoProducto> CarritoProductos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<DetalleFactura> DetalleFacturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}