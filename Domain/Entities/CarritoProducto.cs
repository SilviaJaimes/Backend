namespace Dominio.Entities;

public class CarritoProducto : BaseEntity
{
    public int IdCarritoFk { get; set; }
    public Carrito Carrito { get; set; }
    public int IdProductoFk { get; set; }
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }

    public ICollection<DetalleFactura> DetalleFacturas { get; set; }
}