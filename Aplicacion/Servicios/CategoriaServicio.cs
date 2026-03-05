using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    /// Implementación del servicio de categorías que utiliza un repositorio para realizar operaciones de acceso a datos. Este servicio implementa la interfaz ICategoriaService, lo que permite abstraer la lógica de negocio relacionada con las categorías y facilita la implementación de diferentes servicios que puedan manejar esta funcionalidad.
    public class CategoriaServicio : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaServicio(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
            => await _repository.ObtenerTodasAsync();

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
            => await _repository.ObtenerPorIdAsync(id);

        public async Task AgregarAsync(Categoria categoria)
            => await _repository.AgregarAsync(categoria);

        public async Task ActualizarAsync(Categoria categoria)
            => await _repository.ActualizarAsync(categoria);

        public async Task EliminarAsync(int id)
            => await _repository.EliminarAsync(id);
    }
}