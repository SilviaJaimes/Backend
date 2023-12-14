using Dominio.Entities;

namespace API.Dtos;

public class FacturaDto : BaseEntity
{
    public decimal PrecioTotal { get; set; }
    public int CantidadTotal { get; set; }
    public int IdClienteFk { get; set; }
    public ClienteDto Cliente { get; set; }
}