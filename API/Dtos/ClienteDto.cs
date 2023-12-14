using Dominio.Entities;

namespace API.Dtos;

public class ClienteDto : BaseEntity
{
    public string Documento { get; set; }
    public string PrimerNombre { get; set; }
    public string SegundoNombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int IdUsuarioFk { get; set; }
    public UsuarioDto Usuario { get; set; }
    public int RolIdFk { get; set; }
    public RolDto Rol { get; set; }
}