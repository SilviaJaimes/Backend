using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetalleFacturaRepository : GenericRepository<DetalleFactura>, IDetalleFactura
{
    private readonly ApiContext _context;

    public DetalleFacturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleFactura>> GetAllAsync()
    {
        return await _context.DetalleFacturas
            .ToListAsync();
    }

    public override async Task<DetalleFactura> GetByIdAsync(int id)
    {
        return await _context.DetalleFacturas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<DetalleFactura> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.DetalleFacturas as IQueryable<DetalleFactura>;

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