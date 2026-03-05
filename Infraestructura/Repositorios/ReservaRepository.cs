using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    // Implementación del repositorio de pedidos que utiliza Entity Framework Core para realizar operaciones de acceso a datos. Este repositorio implementa la interfaz IPedidoRepository, lo que permite abstraer la lógica de acceso a datos relacionada con los pedidos y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public class ReservaRepository : IReservaRepository
    {
        private readonly HechizoDbContext _context;

        public ReservaRepository(HechizoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasAsync()
            => await _context.Reservas
                .Include(r => r.Cliente)
                .ToListAsync();

        public async Task<Reserva?> ObtenerPorIdAsync(int id)
            => await _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task AgregarAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                _context.Reservas.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}