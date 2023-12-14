namespace Dominio.Entities;

public class DetalleFactura : BaseEntity
{
    public int IdCarritoProductoFk { get; set; }
    public CarritoProducto CarritoProducto { get; set; }
    public int IdFacturaFk { get; set;}
    public Factura Factura { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
}