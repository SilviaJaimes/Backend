namespace Dominio.Entities;

public class Carrito : BaseEntity
{
    public int IdClienteFk { get; set; }
    public Cliente Cliente { get; set; }
    public bool Vendido { get; set; }

    public ICollection<CarritoProducto> CarritoProductos { get; set; }
}