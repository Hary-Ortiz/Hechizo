using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    // Implementación del repositorio de categorías que utiliza Entity Framework Core para realizar operaciones de acceso a datos. Este repositorio implementa la interfaz ICategoriaRepository, lo que permite abstraer la lógica de acceso a datos relacionada con las categorías y facilita la implementación de diferentes repositorios que puedan manejar esta funcionalidad.
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly HechizoDbContext _context;

        public CategoriaRepository(HechizoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
            => await _context.Categorias.ToListAsync();

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
            => await _context.Categorias.FindAsync(id);

        public async Task AgregarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad != null)
            {
                _context.Categorias.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}