using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol,RolDto>().ReverseMap();
        CreateMap<Usuario,UsuarioDto>().ReverseMap();
        CreateMap<Carrito,CarritoDto>().ReverseMap();
        CreateMap<CarritoProducto,CarritoProductoDto>().ReverseMap();
        CreateMap<Categoria,CategoriaDto>().ReverseMap();
        CreateMap<Cliente,ClienteDto>().ReverseMap();
        CreateMap<DetalleFactura,DetalleFacturaDto>().ReverseMap();
        CreateMap<Factura,FacturaDto>().ReverseMap();
        CreateMap<Producto,ProductoDto>().ReverseMap();
    }
}