using Dominio.Entities;

namespace API.Dtos;

public class DetalleFacturaDto : BaseEntity
{
    public int IdCarritoProductoFk { get; set; }
    public CarritoProductoDto CarritoProducto { get; set; }
    public int IdFacturaFk { get; set;}
    public FacturaDto Factura { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
}