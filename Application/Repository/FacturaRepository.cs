using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class FacturaRepository : GenericRepository<Factura>, IFactura
{
    private readonly ApiContext _context;

    public FacturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas
            .ToListAsync();
    }

    public override async Task<Factura> GetByIdAsync(int id)
    {
        return await _context.Facturas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Factura> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Facturas as IQueryable<Factura>;

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