using Dominio.Entities;

namespace API.Dtos;

public class CarritoDto : BaseEntity
{
    public int IdClienteFk { get; set; }
    public ClienteDto Cliente { get; set; }
    public bool Vendido { get; set; }
}