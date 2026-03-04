using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly HechizoDbContext _context;

        public PedidoRepository(HechizoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> ObtenerTodosAsync()
            => await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .ToListAsync();

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
            => await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AgregarAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                _context.Pedidos.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}