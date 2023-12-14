using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CarritoProductoRepository : GenericRepository<CarritoProducto>, ICarritoProducto
{
    private readonly ApiContext _context;

    public CarritoProductoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CarritoProducto>> GetAllAsync()
    {
        return await _context.CarritoProductos
            .ToListAsync();
    }

    public override async Task<CarritoProducto> GetByIdAsync(int id)
    {
        return await _context.CarritoProductos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<CarritoProducto> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.CarritoProductos as IQueryable<CarritoProducto>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}