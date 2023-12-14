using Dominio.Entities;

namespace API.Dtos;

public class ProductoDto : BaseEntity
{
    public string Titulo { get; set; }
    public string Imagen { get; set; }
    public int IdCategoriaFk { get; set; }
    public CategoriaDto Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}