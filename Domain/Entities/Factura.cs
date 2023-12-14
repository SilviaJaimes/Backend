namespace Dominio.Entities;

public class Factura : BaseEntity
{
    public decimal PrecioTotal { get; set; }
    public int CantidadTotal { get; set; }
    public int IdClienteFk { get; set; }
    public Cliente Cliente { get; set; }

    public ICollection<DetalleFactura> DetalleFacturas { get; set; }
}