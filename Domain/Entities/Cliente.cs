using Microsoft.AspNetCore.Identity;

namespace Dominio.Entities;

public class Cliente : BaseEntity
{
    public string Documento { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int IdUsuarioFk { get; set; }
    public Usuario Usuario { get; set; }

    public ICollection<Carrito> Carritos { get; set; }
    public ICollection<Factura> Facturas { get; set; }
}