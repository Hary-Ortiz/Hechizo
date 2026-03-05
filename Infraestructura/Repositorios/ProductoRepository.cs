using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    // Implementación del repositorio de pedidos que utiliza Entity Framework Core para realizar operaciones de acceso a datos. Este repositorio implementa la interfaz IPedidoRepository, lo que permite abstraer la lógica de acceso a datos relacionada con los pedidos y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public class ProductoRepository : IProductoRepository
    {
        private readonly HechizoDbContext _context;

        public ProductoRepository(HechizoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
            => await _context.Productos.ToListAsync();

        public async Task<Producto?> ObtenerPorIdAsync(int id)
            => await _context.Productos.FindAsync(id);

        public async Task AgregarAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                _context.Productos.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}