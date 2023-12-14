using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private RolRepository _roles;
    private UsuarioRepository _usuarios;
    private CarritoRepository _carritos;
    private CarritoProductoRepository _carritoProductos;
    private ClienteRepository _clientes;
    private CategoriaRepository _categorias;
    private DetalleFacturaRepository _detallesFacturas;
    private FacturaRepository _facturas;
    private ProductoRepository _productos;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public ICarrito Carritos
    {
        get
        {
            if (_carritos == null)
            {
                _carritos = new CarritoRepository(_context);
            }
            return _carritos;
        }
    }

    public ICarritoProducto CarritoProductos
    {
        get
        {
            if (_carritoProductos == null)
            {
                _carritoProductos = new CarritoProductoRepository(_context);
            }
            return _carritoProductos;
        }
    }

    public ICategoria Categorias
    {
        get
        {
            if (_categorias == null)
            {
                _categorias = new CategoriaRepository(_context);
            }
            return _categorias;
        }
    }

    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IDetalleFactura DetalleFacturas
    {
        get
        {
            if (_detallesFacturas == null)
            {
                _detallesFacturas = new DetalleFacturaRepository(_context);
            }
            return _detallesFacturas;
        }
    }

    public IFactura Facturas
    {
        get
        {
            if (_facturas == null)
            {
                _facturas = new FacturaRepository(_context);
            }
            return _facturas;
        }
    }

    public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}