namespace Dominio.Interfaces;

public interface IUnitOfWork
{
        IRol Roles { get; }
        IUsuario Usuarios { get; }
        ICarrito Carritos { get; }
        ICarritoProducto CarritoProductos { get; }
        ICategoria Categorias { get; }
        ICliente Clientes { get; }
        IDetalleFactura DetalleFacturas { get; }
        IFactura Facturas { get; }
        IProducto Productos { get; }
        Task<int> SaveAsync();
}