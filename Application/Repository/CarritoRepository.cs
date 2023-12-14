using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CarritoRepository : GenericRepository<Carrito>, ICarrito
{
    private readonly ApiContext _context;

    public CarritoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Carrito>> GetAllAsync()
    {
        return await _context.Carritos
            .ToListAsync();
    }

    public override async Task<Carrito> GetByIdAsync(int id)
    {
        return await _context.Carritos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Carrito> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Carritos as IQueryable<Carrito>;

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