using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
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