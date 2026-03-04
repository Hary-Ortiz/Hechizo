using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly HechizoDbContext _context;

        public ClienteRepository(HechizoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
            => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
            => await _context.Clientes.FindAsync(id);

        public async Task AgregarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                _context.Clientes.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}